using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.StartCountDown
{
    public interface IStartCountDownMessage
    {
    }

    public class StartCountDownMessageBroker : TypedMessageBroker<IStartCountDownMessage>
    {
    }
}