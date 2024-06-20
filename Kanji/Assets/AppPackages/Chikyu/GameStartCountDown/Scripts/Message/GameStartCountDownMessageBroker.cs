using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.GameStartCountDown
{
    public interface IMessageTypeGameStartCountDown
    {
    }

    public class GameStartCountDownMessageBroker : TypedMessageBroker<IMessageTypeGameStartCountDown>
    {
    }

}