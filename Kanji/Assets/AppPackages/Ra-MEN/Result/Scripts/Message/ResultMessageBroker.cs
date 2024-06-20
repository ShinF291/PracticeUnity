using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.Result
{
    public interface IResultMessage
    {
    }

    public class ResultMessageBroker : TypedMessageBroker<IResultMessage>
    {
    }
}
