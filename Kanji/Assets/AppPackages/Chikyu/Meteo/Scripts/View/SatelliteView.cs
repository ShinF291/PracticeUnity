using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using MamoriOfChikyu.AudioSourceMessage;
using UnityEngine.Events;
using System;

namespace MamoriOfChikyu.Meteo
{
    public class SatelliteView : CharacterView
    {
        [Inject]
        AudioSourceMessageBroker _AudioSourceMessageBroker;

        private bool _SatelliteMoveFlag;

        private float _Speed;

        private UnityAction SatelliteDestroyedMessage;

        void Awake()
        {
            _AudioSourceMessageBroker.Publish(new AudioSourceMessageRequestOnSatellite());

            _SatelliteMoveFlag = true;
        }

        void FixedUpdate()
        {
            if(_SatelliteMoveFlag)
            {
                this.transform.RotateAround (Vector3.zero, Vector3.forward, _Speed);
            }  
        }

        public void Init(UnityAction SatelliteDestroyedMessageAction, float speed)
        {
            SatelliteDestroyedMessage = SatelliteDestroyedMessageAction;
            _Speed = speed;

        }

        public void StopSatelliteMove()
        {
            _SatelliteMoveFlag = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                _AudioSourceMessageBroker.Publish(new AudioSourceMessageRequestSatelliteDestroy());
                SatelliteDestroyedMessage.Invoke();
                Destroy( this.gameObject );
            }
        }
    }
}
