using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Common.Timer;
using Common.SoundManager;
using RaMen.FinishGameAnimation;
using RaMen.Result;
using RaMen.Score;
using RaMen.Guzai;
using RaMen.GuzaiCreate;
using RaMen.QuestionAnswer;
using RaMen.AnswerJudgment;
using RaMen.UIButton;
using RaMen.CorrectAnimation;
using RaMen.StartCountDown;
using RaMen.RamenData;

namespace RaMen
{
    public class RamenSceneController : MonoBehaviour
    {
        [Inject]
        private SoundManager _SoundManager;

        [Inject]
        private RaMen.RamenData.RamenData _RamenData;

        [Inject]
        private RamenSceneStateManager _RamenSceneStateManager;

        [Inject]
        private GuzaiMessageBroker _GuzaiMessageBroker;

        [Inject]
        private TimerMessageBroker _TimerMessageBroker;

        [Inject]
        private FinishGameAnimationMessageBroker _FinishGameAnimationMessageBroker;

        [Inject]
        private ResultMessageBroker _ResultMessageBroker;

        [Inject]
        private ScoreMessageBroker _ScoreMessageBroker;

        [Inject]
        private AnswerJudgmentMessageBroker _AnswerJudgmentMessageBroker;

        [Inject]
        private GuzaiCreateMessageBroker _GuzaiCreateMessageBroker;

        [Inject]
        private QuestionAnswerMessageBroker _QuestionAnswerMessageBroker;

        [Inject]
        private UIButtonMessageBroker _UIButtonMessageBroker;

        [Inject]
        private CorrectAnimationMessageBroker _CorrectAnimationMessageBroker;

        [Inject]
        private StartCountDownMessageBroker _StartCountDownMessageBroker;

        [SerializeField]
        private AudioClip RamenBgm;

        private int _GuzaiMessageCount = 0;

        private List<KeyValuePair<int, Transform>> _UsersGuzaiList = new List<KeyValuePair<int, Transform>>();
        private List<KeyValuePair<int, Transform>> _AnswersGuzaiList = new List<KeyValuePair<int, Transform>>();
        
        void Awake()
        {
            _StartCountDownMessageBroker.Receive<StartCountDownResponse>()
            .Subscribe(_=>
            {
                _SoundManager.PlayBgm(RamenBgm);
                this.StartCreateGuzai();
            })
            .AddTo(this);

            _GuzaiCreateMessageBroker.Receive<GuzaiCreateResponse>()
            .Subscribe(_=>
            {
                this.InitGuzai(_.DropArea);
                this.StartTimer();
                _RamenSceneStateManager.SetState(RamenSceneState.StartQuestion);
            })
            .AddTo(this);

            _QuestionAnswerMessageBroker.Receive<QuestionAnswerCreateResponse>()
            .Subscribe(_=>
            {
                _RamenSceneStateManager.SetState(RamenSceneState.Play);
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<GetGuzaiDataResponse>()
            .Subscribe(_=>
            {
                _GuzaiMessageCount++;

                if(_.UsersObj)
                {
                    _UsersGuzaiList.Add(new KeyValuePair<int, Transform>(_.GuzaiId, _.GuzaiPosition));
                }else{
                    _AnswersGuzaiList.Add(new KeyValuePair<int, Transform>(_.GuzaiId, _.GuzaiPosition));
                }

                if(_GuzaiMessageCount >= _.MoveObjCount + _RamenData.AnswerGuzai)
                {
                    Debug.Log("座標取得完了");
                    _QuestionAnswerMessageBroker.Publish(new GetRelativePointRequest());
                }
                
            })
            .AddTo(this);

            _QuestionAnswerMessageBroker.Receive<GetRelativePointResponse>()
            .Subscribe(_=>
            {
                _AnswerJudgmentMessageBroker.Publish(new AnswerJudgeRequest(_UsersGuzaiList, _AnswersGuzaiList,
                                                     _.UserRelativePoint, _.AnswerRelativePoint, _RamenData.PositionDifference));
                _GuzaiMessageCount = 0;
                _UsersGuzaiList = new List<KeyValuePair<int, Transform>>();
                _AnswersGuzaiList = new List<KeyValuePair<int, Transform>>();
            })
            .AddTo(this);

            _AnswerJudgmentMessageBroker.Receive<AnswerJudgeResponse>()
            .Subscribe(_=>
            {
                Debug.Log("結果 : "+ _.JudgeResult);
                if(_.JudgeResult)
                {
                    _ScoreMessageBroker.Publish(new ScoreUPRequest());
                    _CorrectAnimationMessageBroker.Publish(new CorrectAnimationRequest());

                }else{
                    _CorrectAnimationMessageBroker.Publish(new IncorrectAnimationRequest());
                }
            })
            .AddTo(this);

            _CorrectAnimationMessageBroker.Receive<CorrectAnimationResponse>()
            .Subscribe(_=>
            {
                _RamenSceneStateManager.SetState(RamenSceneState.StartQuestion);
            })
            .AddTo(this);

            _CorrectAnimationMessageBroker.Receive<IncorrectAnimationResponse>()
            .Subscribe(_=>
            {
                _RamenSceneStateManager.SetState(RamenSceneState.Play);
            })
            .AddTo(this);
            
            _TimerMessageBroker.Receive<TimeOver>()
            .Subscribe(_=>
            {
                this.FinishMessage();
            })
            .AddTo(this);

            _FinishGameAnimationMessageBroker.Receive<FinishGameAnimationResponse>()
            .Subscribe(_=>
            {
                Debug.Log("スコア取得");
                _ScoreMessageBroker.Publish(new ScoreGetRequest());
            })
            .AddTo(this);

            _ScoreMessageBroker.Receive<ScoreGetResponse>()
            .Subscribe(_=>
            {
                _ResultMessageBroker.Publish(new ResultRequest(_.Score, _RamenData.ClearScore));
            })
            .AddTo(this);

            _UIButtonMessageBroker.Receive<AnswerButtonPushed>()
            .Subscribe(_=>
            {
                if(_RamenSceneStateManager.CurrentState.Value == RamenSceneState.Play)
                {
                    _GuzaiMessageBroker.Publish(new GetGuzaiDataRequest());
                }
                
            })
            .AddTo(this);

            _UIButtonMessageBroker.Receive<ResetButtonPushed>()
            .Subscribe(_=>
            {
                if(_RamenSceneStateManager.CurrentState.Value == RamenSceneState.Play)
                {
                    _GuzaiMessageBroker.Publish(new GuzaiResetOnRamenRequest());
                }
                
            })
            .AddTo(this);

            _RamenSceneStateManager.CurrentState
                .SkipLatestValueOnSubscribe()
                .Where(_ => _ == RamenSceneState.StartQuestion)
                .Subscribe(_ =>
                {
                    _GuzaiMessageBroker.Publish(new GuzaiResetAnswerRequest());
                    _GuzaiMessageBroker.Publish(new GuzaiResetOnRamenRequest());
                    this.StartQuestion();
                }).AddTo(this);

            _RamenSceneStateManager.CurrentState
                .SkipLatestValueOnSubscribe()
                .Where(_ => _ == RamenSceneState.Play)
                .Subscribe(_ =>
                {
                   _GuzaiMessageBroker.Publish(new GuzaiUnlockedTouchRequest());
                }).AddTo(this);

            _RamenSceneStateManager.CurrentState
                .SkipLatestValueOnSubscribe()
                .Where(_ => _ == RamenSceneState.CorrectAnimation)
                .Subscribe(_ =>
                {
                   _GuzaiMessageBroker.Publish(new GuzaiForbiddenTouchRequest());
                }).AddTo(this);
            
            _RamenSceneStateManager.CurrentState
                .SkipLatestValueOnSubscribe()
                .Where(_ => _ == RamenSceneState.Result)
                .Subscribe(_ =>
                {
                   _GuzaiMessageBroker.Publish(new GuzaiForbiddenTouchRequest());
                   _FinishGameAnimationMessageBroker.Publish(new FinishGameAnimationRequest());
                }).AddTo(this);


        }

        void Start()
        {
            _StartCountDownMessageBroker.Publish(new StartCountDownRequest());
        }

        private void StartTimer()
        {
            _TimerMessageBroker.Publish(new TimerStartRequest(_RamenData.Time));
        }

        private void StartQuestion()
        {
            _QuestionAnswerMessageBroker.Publish(new QuestionAnswerCreateRequest(_RamenData.AnswerGuzai));
        }


        private void StartCreateGuzai()
        {
            _GuzaiCreateMessageBroker.Publish(new GuzaiCreateRequest());
        }

        private void InitGuzai(RectTransform dropArea)
        {
            _GuzaiMessageBroker.Publish(new InitGuzai(dropArea));
        }

        private void FinishMessage()
        {
            _RamenSceneStateManager.SetState(RamenSceneState.Result);

        }

    }
}
