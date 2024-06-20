using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using MamoriOfChikyu.AudioSourceMessage;
using System;
using UnityEngine.Events;

namespace MamoriOfChikyu.Meteo
{
    public class MeteoView : CharacterView
    {
        [Inject]
        private AudioSourceMessageBroker _AudioSourceMessageBroker;

        private bool _MeteoMoveFlag;

        private float _Speed;
        private int _Atk;

        private Vector2 _Position;

        private float _Radian;

        private Vector3 _Direction;

        private Vector3 _Vector;

        private UnityAction<int> _ChikyuHitAction;

        private readonly int VECTOR_Z_ZERO = 0;

        void Awake()
        {
            _MeteoMoveFlag = true;
        }

        void Start()
        {
            _Position = transform.position;

            _Radian = (float)Math.Atan2(_Position.y, _Position.x);

            _Direction = new Vector3(Mathf.Cos(_Radian), Mathf.Sin(_Radian), VECTOR_Z_ZERO);
            
            _Vector = _Direction * _Speed;
        }

        void FixedUpdate()
        {
            if(_MeteoMoveFlag)
            {
                transform.position -= _Vector;
            }
            
        }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
                _AudioSourceMessageBroker.Publish(new AudioSourceMessageRequestExplosion());
                
                Destroy(this.gameObject);
        }

        if (collision.tag == "Chikyu")
        {
                _ChikyuHitAction(_Atk);
                _AudioSourceMessageBroker.Publish(new AudioSourceMessageRequestExplosion2());
                Destroy( this.gameObject );
        }
    }

    public void Init(UnityAction<int> chikyuHitAction, float speed, int atk)
    {
            _ChikyuHitAction = chikyuHitAction;
            _Speed = speed;
            _Atk = atk;
    }

    public void StopMeteo()
    {
            _MeteoMoveFlag = false;
    }

    }
}
