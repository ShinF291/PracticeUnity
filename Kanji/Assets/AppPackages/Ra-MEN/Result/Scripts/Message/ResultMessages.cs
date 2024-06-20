using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.Result
{
    public class ResultRequest : IResultMessage
    {
        public int Score;

        public int ClearScore;

        public ResultRequest(int score, int clearScore)
        {
            Score = score;
            ClearScore = clearScore;
        }
    }

    public class ResultResponse : IResultMessage
    {
    }
}
