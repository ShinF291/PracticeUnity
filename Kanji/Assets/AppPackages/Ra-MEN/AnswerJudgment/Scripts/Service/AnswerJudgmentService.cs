using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.AnswerJudgment
{
    public class AnswerJudgmentService
    {
        public bool JudgeCorrectThisAnswer(List<KeyValuePair<int, Transform>> usersGuzaiList, List<KeyValuePair<int, Transform>> answersGuzaiList,
                    Transform userRelativePoint, Transform answerRelativePoint, float difference)
        {
            KeyValuePair<int, Transform> correct = new KeyValuePair<int, Transform>();
            int correctCount = 0;
            Debug.Log(usersGuzaiList.Count);

            foreach (var answersKeyValuePair in answersGuzaiList)
            {   
                if (usersGuzaiList == null || usersGuzaiList.Count == 0) return false;

                foreach (var usersKeyValuePair in usersGuzaiList)
                {
                    bool judgeResult = false;

                    // 同じIDのとき
                    if(usersKeyValuePair.Key == answersKeyValuePair.Key)
                    {
                        judgeResult = this.JudgeAnswer(usersKeyValuePair.Value, userRelativePoint,
                                        answersKeyValuePair.Value, answerRelativePoint, difference);
                        
                        Debug.Log(judgeResult);

                        if(judgeResult)
                        {
                            correct = usersKeyValuePair;
                            break;
                        }
                    }
                }

                if(correct.Value != null)
                {
                    usersGuzaiList.Remove(correct);
                    correct = new KeyValuePair<int, Transform>();
                    correctCount++;
                }
            }
            Debug.Log(usersGuzaiList.Count +" : "+correctCount);
            return usersGuzaiList.Count == 0 && correctCount == answersGuzaiList.Count;
        }        

        private bool JudgeAnswer(Transform userGuzaiPositon, Transform userRelativePoint, 
                                    Transform answerGuzaiPositon, Transform answerRelativePoint, float difference)
        {
            return this.ComparePosition(this.RelativePosition(userGuzaiPositon, userRelativePoint),
                                        this.RelativePosition(answerGuzaiPositon, answerRelativePoint), difference);
        }

        private Vector2 RelativePosition(Transform guzaiPositon, Transform relativePoint)
        {
            var relativePos = guzaiPositon.position - relativePoint.position;
            return relativePos;
        }

        private bool ComparePosition(Vector2 position1, Vector2 position2, float difference)
        {
            float distance = Vector2.Distance(position1, position2);
            Debug.Log(position1);
            Debug.Log(position2);
            Debug.Log(distance);
            return distance <= difference;
        }
    }
}
