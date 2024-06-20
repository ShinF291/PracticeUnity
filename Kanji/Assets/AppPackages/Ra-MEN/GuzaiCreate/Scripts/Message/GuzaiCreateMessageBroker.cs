using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.GuzaiCreate
{
    public interface IGuzaiCreateMessage
    {
    }

    public class GuzaiCreateMessageBroker : TypedMessageBroker<IGuzaiCreateMessage>
    {
    }
}