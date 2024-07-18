using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace RaMen.QuestionAnswer
{
    public interface IQuestionAnswerMessage
    {
    }

    public class QuestionAnswerMessageBroker : TypedMessageBroker<IQuestionAnswerMessage>
    {
    }
}