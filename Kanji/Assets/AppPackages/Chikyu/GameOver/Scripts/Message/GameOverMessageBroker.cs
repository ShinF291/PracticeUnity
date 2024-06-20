using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.GameOver
{
    public interface IMessageTypeGameOver
    {
    }

    public class GameOverMessageBroker : TypedMessageBroker<IMessageTypeGameOver>
    {

    }

}