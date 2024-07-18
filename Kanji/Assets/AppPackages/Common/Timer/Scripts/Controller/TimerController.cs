using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Common.Timer
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField]
        private TimerView _TimerView;

        [Inject]
        private TimerMessageBroker _TimerMessageBroker;

        [Inject]
        private TimerModel _TimerModel;

        private Coroutine _TimerCoroutine;

        void Awake()
        {
            _TimerMessageBroker.Receive<TimerStartRequest>()
            .Subscribe(_=>{this.StartTimer(_.Time);})
            .AddTo(this);

            _TimerMessageBroker.Receive<TimerStopRequest>()
            .Subscribe(_=>{this.StopTimer();})
            .AddTo(this);
        }

        void Start()
        {
             _TimerModel._TimerProperty
                .SkipLatestValueOnSubscribe()
                .Subscribe(Time => {

                    _TimerView.ForwardTimerGauge(Time); ///
                    _TimerMessageBroker.Publish(new TimeStep());
                    
                    if(_TimerModel.JudgeTimeFinish(Time)) ///
                    {
                        Debug.Log("時間切れ！");
                        _TimerMessageBroker.Publish(new TimeOver());
                    }
                    
                })
                .AddTo(this);
        }

        public void StartTimer(int time)
        {
            Debug.Log("タイマー スタート！");
            _TimerCoroutine = StartCoroutine(_TimerModel.TimerCountDown(time));
        }
        

        public void StopTimer()
        {
            StopCoroutine(_TimerCoroutine);
        }

    }
}
