using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using UnityEngine.Events;

namespace MamoriOfChikyu.Meteo
{
    public class SatellitePresenter : CharacterPresenter<SatelliteDatas>
    {
        [Inject]
        private MeteoMessageBroker _MeteoMessageBroker;

        [SerializeField]
        private SatelliteView _SatelliteView;

        public void StopSatelliteMove()
        {
            _SatelliteView.StopSatelliteMove();
        }

        public override void Init(SatelliteDatas satelliteDatas)
        {
            _SatelliteView.Init(satelliteDatas.SatelliteDestroyedMessageAction, satelliteDatas.Speed);
        }

    }

    public class SatelliteDatas : Datas
    {
        public UnityAction SatelliteDestroyedMessageAction;
        public float Speed;

        public SatelliteDatas(UnityAction satelliteDestroyedMessageAction, float speed)
        {
            SatelliteDestroyedMessageAction = satelliteDestroyedMessageAction;
            Speed = speed;
        }
    }
}
