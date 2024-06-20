using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace Common.Timer
{
    public interface ITimerMessage
    {
    }

    public class TimerMessageBroker : TypedMessageBroker<ITimerMessage>
    {

    }

}

