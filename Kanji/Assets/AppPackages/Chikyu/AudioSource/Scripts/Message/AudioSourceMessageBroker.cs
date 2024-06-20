using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.AudioSourceMessage
{
    public interface IMessageTypeAudioSource
    {
    }

    public class AudioSourceMessageBroker : TypedMessageBroker<IMessageTypeAudioSource>
    {
    }
}
