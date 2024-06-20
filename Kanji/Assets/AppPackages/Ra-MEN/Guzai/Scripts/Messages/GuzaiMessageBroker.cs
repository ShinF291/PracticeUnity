using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.Guzai
{
    public interface IGuzaiMessage
    {
    }

    public class GuzaiMessageBroker : TypedMessageBroker<IGuzaiMessage>
    {
    }
}