using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;
using System;

namespace Common.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField]
        private Image _TimerGauge;

        public void ForwardTimerGauge(float time)
        {
            _TimerGauge.fillAmount = time;
        }
    }
}
