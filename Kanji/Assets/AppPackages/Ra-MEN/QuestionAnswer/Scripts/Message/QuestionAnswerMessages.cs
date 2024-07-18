using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.QuestionAnswer
{
    public class QuestionAnswerCreateRequest : IQuestionAnswerMessage
    {
        public int Number;

        public QuestionAnswerCreateRequest(int number)
        {
            Number = number;
        }
    }

    public class QuestionAnswerCreateResponse : IQuestionAnswerMessage
    {
    }

    public class GetRelativePointRequest : IQuestionAnswerMessage
    {
    }

    public class GetRelativePointResponse : IQuestionAnswerMessage
    {
        public Transform UserRelativePoint;
        public Transform AnswerRelativePoint;

        public GetRelativePointResponse(Transform userRelativePoint, Transform answerRelativePoint)
        {
            UserRelativePoint = userRelativePoint;
            AnswerRelativePoint = answerRelativePoint;
        }


    }
}
