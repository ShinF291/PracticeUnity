using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.Timer
{
    public class TimerStartRequest : ITimerMessage
    {

    }

    public class TimerStopRequest : ITimerMessage
    {

    }
    

    public class timeOver: ITimerMessage
    {

    }

    public class TimeStep : ITimerMessage
    {

    }
    
}
