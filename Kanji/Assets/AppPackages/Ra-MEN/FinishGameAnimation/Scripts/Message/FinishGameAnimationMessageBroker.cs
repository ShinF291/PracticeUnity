using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.FinishGameAnimation
{
    public interface IFinishGameAnimationMessage
    {
    }

    public class FinishGameAnimationMessageBroker : TypedMessageBroker<IFinishGameAnimationMessage>
    {
    }
}
