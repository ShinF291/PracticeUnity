using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.Result
{
    public class ResultRequest : IMessageType1
    {
        public int BP;
        public int UFOScore;

        public ResultRequest(int bp, int ufoScore)
        {
            BP = bp;
            UFOScore = ufoScore;
        }
    }

    public class ResultResponse : IMessageType1
    {
    }
}
