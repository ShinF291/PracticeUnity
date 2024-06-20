using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.Score
{
    public class ScoreUPRequest : IScoreMessage
    {
    }

    public class ScoreGetRequest : IScoreMessage
    {
    }

    public class ScoreGetResponse : IScoreMessage
    {
        public int Score ;

        public ScoreGetResponse(int score)
        {
            Score = score;
        }
    }

}