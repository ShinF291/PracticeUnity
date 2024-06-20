using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace MamoriOfChikyu.Timer
{
    public class CountDownTimer : MonoBehaviour
    {

        [SerializeField]
        private float _TimerTime;

        [SerializeField]
        private TimerView _TimerView;

        [Inject]
        private CountDownTimerMessageBroker _CountDownTimerMessageBroker;

        [Inject]
        private CountDownTimerModel _CountDownTimerModel;

        private Coroutine _TimerCoroutine;

        void Awake()
        {
            _CountDownTimerMessageBroker.Receive<TimerStartRequest>()
            .Subscribe(_=>{this.StartTimer();})
            .AddTo(this);

            _CountDownTimerMessageBroker.Receive<TimerStopRequest>()
            .Subscribe(_=>{this.StopTimer();})
            .AddTo(this);
        }

        void Start()
        {
             _CountDownTimerModel._TimerProperty
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => {

                    _TimerView.ForwardTimerGauge(x);
                    _CountDownTimerMessageBroker.Publish(new TimeStep());
                    
                    if(x <= 0)_CountDownTimerMessageBroker.Publish(new timeOver());
                    
                })
                .AddTo(this);
        }

        public void StartTimer()
        {
            _TimerCoroutine = StartCoroutine(_CountDownTimerModel.TimerCountDown(_TimerTime));
        }
        

        public void StopTimer()
        {
            StopCoroutine(_TimerCoroutine);
        }

    }
}
