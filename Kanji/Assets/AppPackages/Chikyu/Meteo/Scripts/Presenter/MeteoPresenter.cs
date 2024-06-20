using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using UnityEngine.Events;

namespace MamoriOfChikyu.Meteo
{
    public class MeteoPresenter: CharacterPresenter<MeteoDatas>
    {
        [Inject]
        private MeteoMessageBroker _MeteoMessageBroker;

        [SerializeField]
        private MeteoView _MeteoView;

        void Awake()
        {
            _MeteoMessageBroker.Receive<MeteoStopRequest>()
            .Subscribe(_=>{ _MeteoView.StopMeteo(); })
            .AddTo(this);

        }

        public override void Init(MeteoDatas meteoDatas)
        {
            _MeteoView.Init(meteoDatas.ChikyuHitAction, meteoDatas.Speed, meteoDatas.Atk);
        }

    }

    public class MeteoDatas : Datas
    {
        public UnityAction<int> ChikyuHitAction;
        public float Speed;
        public int Atk;

        public MeteoDatas(UnityAction<int> chikyuHitAction, float speed ,int atk)
        {
            ChikyuHitAction = chikyuHitAction;
            Speed = speed;
            Atk = atk;
        }
    }
}
