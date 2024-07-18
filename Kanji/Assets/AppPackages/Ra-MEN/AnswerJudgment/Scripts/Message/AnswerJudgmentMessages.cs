using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.AnswerJudgment
{
    public class AnswerJudgeRequest : IAnswerJudgmentMessage
    {
        public List<KeyValuePair<int, Transform>> UsersGuzaiList;
        public List<KeyValuePair<int, Transform>> AnswersGuzaiList;
        public Transform UserRelativePoint;
        public Transform AnswerRelativePoint;
        public float Difference;

        public AnswerJudgeRequest(List<KeyValuePair<int, Transform>> usersGuzaiList, List<KeyValuePair<int, Transform>> answersGuzaiList,
                                    Transform userRelativePoint, Transform answerRelativePoint, float difference)
        {
            UsersGuzaiList = usersGuzaiList;
            AnswersGuzaiList = answersGuzaiList;
            UserRelativePoint = userRelativePoint;
            AnswerRelativePoint = answerRelativePoint;
            Difference = difference;
        }

    }

    public class AnswerJudgeResponse : IAnswerJudgmentMessage
    {
        public bool JudgeResult;

        public AnswerJudgeResponse(bool judgeResult)
        {
            JudgeResult = judgeResult;
        }

    }
}
