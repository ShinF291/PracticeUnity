using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.Player
{
    public interface IPlayerMessage
    {
    }

    public class PlayerMessageBroker : TypedMessageBroker<IPlayerMessage>
    {

    }

}
