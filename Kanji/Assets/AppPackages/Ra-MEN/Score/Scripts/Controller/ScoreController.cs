using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace RaMen.Score
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
            _ScoreModel.RamenScore
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                _ScoreView.UpdateScore(_);
            })
            .AddTo(this);

            _ScoreMessageBroker.Receive<ScoreUPRequest>()
            .Subscribe(_=>{ _ScoreModel.IncrementRamenScore();})
            .AddTo(this);

            _ScoreMessageBroker.Receive<ScoreGetRequest>()
            .Subscribe(_=>
            { 
                _ScoreMessageBroker.Publish(new ScoreGetResponse(_ScoreModel.GetRamenScore()));
            })
            .AddTo(this);

            _ScoreModel.Init();
        }

    }
}
