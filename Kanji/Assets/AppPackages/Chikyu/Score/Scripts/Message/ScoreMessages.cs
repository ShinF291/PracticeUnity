using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.Score
{
    public class ScoreStartRequest : IScoreMessage
    {
    }

    public class ScoreStopRequest : IScoreMessage
    {
    }

    public class ReduceBP : IScoreMessage
    {
        public int Value ;

        public ReduceBP(int value)
        {
            Value = value;
        }
    }

    public class UFOScoreUPRequest : IScoreMessage
    {
    }

    public class ScoreGetRequest : IScoreMessage
    {
    }

    public class ScoreGetResponse : IScoreMessage
    {
        public int BP ;
        public int UFOScore ;

        public ScoreGetResponse(int bp, int ufoScore)
        {
            BP = bp;
            UFOScore = ufoScore;
        }
    }

    public class ScoreExtinct : IScoreMessage
    {
    }

}