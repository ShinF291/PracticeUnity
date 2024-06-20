using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MamoriOfChikyu.Timer
{
    public class CountDownTimerModel
    {
       public ReactiveProperty<float> _TimerProperty = new ReactiveProperty<float>();

       public IEnumerator TimerCountDown(float timerTime)
        {
            _TimerProperty.Value = timerTime / timerTime;

            WaitForSeconds _WaitForSeconds = new WaitForSeconds(1); //ToDo

            while(true)
            {

                yield return _WaitForSeconds;

                _TimerProperty.Value -= 1.0f / timerTime;
                
                if( _TimerProperty.Value <= 0) break;

            }
        }

    }
}
