using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.AnswerJudgment
{
    public interface IAnswerJudgmentMessage
    {
    }

    public class AnswerJudgmentMessageBroker : TypedMessageBroker<IAnswerJudgmentMessage>
    {

    }

}

