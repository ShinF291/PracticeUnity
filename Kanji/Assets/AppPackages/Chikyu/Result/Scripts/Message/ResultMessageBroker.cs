using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.Result
{
    public interface IMessageType1
    {
    }

    public class ResultMessageBroker : TypedMessageBroker<IMessageType1>
    {
    }
}
