using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace MamoriOfChikyu.GameOver
{
    public class GameOverPresenter : MonoBehaviour
    {
        [Inject]
        private GameOverMessageBroker _GameOverMessageBroker;

        [Inject]
        private GameOverView _GameOverView;

        void Awake()
        {
            _GameOverMessageBroker.Receive<GameEndRequest>()
            .Subscribe(_=>{ 
                Debug.Log($"GameEnd");
                _GameOverView.PlayGameOverSequence(_.BP <= 0, () => _GameOverMessageBroker.Publish(new GameEndResponse(_.BP, _.UFOScore)));
                })
            .AddTo(this);

        }

    }
}
