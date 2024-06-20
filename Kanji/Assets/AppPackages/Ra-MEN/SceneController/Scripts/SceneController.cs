using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Common.Timer;
using RaMen.FinishGameAnimation;
using RaMen.Result;
using RaMen.Score;
using RaMen.Guzai;
using RaMen.GuzaiCreate;

namespace RaMen
{
    public class SceneController : MonoBehaviour
    {
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
        private GuzaiCreateMessageBroker _GuzaiCreateMessageBroker;
        
        void Awake()
        {
            _GuzaiCreateMessageBroker.Receive<GuzaiCreateResponse>()
            .Subscribe(_=>
            {
                this.InitGuzai(_.DropArea);
                this.StartTimer();
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
                _ResultMessageBroker.Publish(new ResultRequest(_.Score, 3));//クリアスコア
            })
            .AddTo(this);

        }

        void Start()
        {
            this.StartCreateGuzai();
        }

        private void StartTimer()
        {
            _TimerMessageBroker.Publish(new TimerStartRequest());
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
            _FinishGameAnimationMessageBroker.Publish(new FinishGameAnimationRequest());

        }

    }
}
