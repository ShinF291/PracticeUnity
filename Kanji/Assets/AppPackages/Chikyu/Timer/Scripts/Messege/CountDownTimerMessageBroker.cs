using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.Timer
{
    public interface ITimerMessage
    {
    }

    public class CountDownTimerMessageBroker : TypedMessageBroker<ITimerMessage>
    {

    }

}

