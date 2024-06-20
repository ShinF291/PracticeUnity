using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using UniRx;
using MamoriOfChikyu.GameOver;

namespace MamoriOfChikyu.Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private ScoreView _ScoreView;

        [Inject]
        private ScoreMessageBroker _ScoreMessageBroker;

        [Inject]
        private ScoreModel _ScoreModel;

        void Awake()
        {
            _ScoreModel.BP
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                _ScoreView.UpdateBP(_);

                if(_ScoreModel.IsBelowZeroBP()){
                    _ScoreMessageBroker.Publish(new ScoreExtinct()); 
                }
            })
            .AddTo(this);

            _ScoreModel.UFOScore
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                _ScoreView.UpdateUFOScore(_);
            })
            .AddTo(this);

            _ScoreMessageBroker.Receive<ScoreStartRequest>()
            .Subscribe(_=>{ _ScoreModel.ScoreAdd = true; })
            .AddTo(this);

            _ScoreMessageBroker.Receive<ScoreStopRequest>()
            .Subscribe(_=>{ _ScoreModel.ScoreAdd = false; })
            .AddTo(this);

            _ScoreMessageBroker.Receive<ReduceBP>()
            .Subscribe(_=>{ _ScoreModel.ReduceBP(_.Value);})
            .AddTo(this);

            _ScoreMessageBroker.Receive<UFOScoreUPRequest>()
            .Subscribe(_=>{ _ScoreModel.IncrementUFOScore();})
            .AddTo(this);

            _ScoreMessageBroker.Receive<ScoreGetRequest>()
            .Subscribe(_=>
            { 
                _ScoreMessageBroker.Publish(new ScoreGetResponse(_ScoreModel.getBP(),_ScoreModel.getUFOScore()));
            })
            .AddTo(this);

            _ScoreModel.Init();
        }

        void FixedUpdate()
        {
            if(_ScoreModel.ScoreAdd)
            {
                BPUpdate();
            
            }
        }

        public void BPUpdate()
        {
            _ScoreModel.IncrementUpdateCount();
            if(_ScoreModel.JudgeBPAdd()){
                _ScoreModel.ResetUpdateCount();
                _ScoreModel.IncrementBP();
            }

        }

    }
}
