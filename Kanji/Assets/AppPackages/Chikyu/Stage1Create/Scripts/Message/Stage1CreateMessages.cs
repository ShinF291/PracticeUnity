using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.Stage1Create
{
    public class StartPlayerControl : IStage1CreateMessage
    {
    }

    public class EndPlayerControl : IStage1CreateMessage
    {
    }

    public class StopSatelliteRequest : IStage1CreateMessage
    {
    }

    public class AddTime : IStage1CreateMessage
    {
    }

    public class UfoGet : IStage1CreateMessage
    {
    }


    public class ChikyuDamageRequest : IStage1CreateMessage
    {
        public int Damage ;

        public ChikyuDamageRequest(int damage)
        {
            Damage = damage;
        }
    }
    
}

