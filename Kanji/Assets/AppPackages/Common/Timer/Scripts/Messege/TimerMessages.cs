using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Timer
{
    public class TimerStartRequest : ITimerMessage
    {
        public int Time; 

        public TimerStartRequest(int time = 30)
        {
            Time = time;
        }

    }

    public class TimerStopRequest : ITimerMessage
    {

    }
    

    public class TimeOver: ITimerMessage
    {

    }

    public class TimeStep : ITimerMessage
    {

    }
    
}
