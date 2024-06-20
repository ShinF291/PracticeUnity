using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.GameOver
{
    public class GameEndRequest : IMessageTypeGameOver
    {
        public int BP ;
        public int UFOScore;

        public GameEndRequest(int bp, int ufoScore)
        {
            BP = bp;
            UFOScore = ufoScore;
        }

    }

    public class GameEndResponse : IMessageTypeGameOver
    {
        public int BP ;
        public int UFOScore;

        public GameEndResponse(int bp, int ufoScore)
        {
            BP = bp;
            UFOScore = ufoScore;
        }
    }

}

