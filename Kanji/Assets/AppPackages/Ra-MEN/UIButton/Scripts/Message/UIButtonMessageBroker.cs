using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.UIButton
{
    public interface IUIButtonMessage
    {
    }

    public class UIButtonMessageBroker : TypedMessageBroker<IUIButtonMessage>
    {
    }
}