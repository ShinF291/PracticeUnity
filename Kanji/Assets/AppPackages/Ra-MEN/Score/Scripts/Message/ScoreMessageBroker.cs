using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.Score
{
    public interface IScoreMessage
    {
    }

    public class ScoreMessageBroker : TypedMessageBroker<IScoreMessage>
    {
    }

}
