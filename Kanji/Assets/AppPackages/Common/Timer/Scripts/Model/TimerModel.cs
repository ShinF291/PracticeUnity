using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Common.Timer
{
    public class TimerModel
    {
       public ReactiveProperty<float> _TimerProperty = new ReactiveProperty<float>();

       private readonly float TIME_FINISH = 0;

       private readonly float SECOND_STANDARD = 1.0f;

       public IEnumerator TimerCountDown(float timerTime)
        {
            _TimerProperty.Value = SECOND_STANDARD;

            WaitForSeconds _WaitForSeconds = new WaitForSeconds(SECOND_STANDARD);

            while(true)
            {

                yield return _WaitForSeconds;

                _TimerProperty.Value -= SECOND_STANDARD / timerTime; ///
                
                if(this.JudgeTimeFinish(_TimerProperty.Value)) break;

            }
        }
        public bool JudgeTimeFinish(float value){
            return value <= TIME_FINISH;
        }

    }
}
