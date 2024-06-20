using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.Meteo
{
    public class MeteoStopRequest : IMeteoMessage
    {
    }

    public class UfoListAdd : IMeteoMessage
    {
        public Vector3 UfoVec ;

        public UfoListAdd(Vector3 ufoVec)
        {
            UfoVec = ufoVec;
        }
    }

    public class UfoListRemove : IMeteoMessage
    {
        public Vector3 UfoVec ;

        public UfoListRemove(Vector3 ufoVec)
        {
            UfoVec = ufoVec;
        }
    }
}
