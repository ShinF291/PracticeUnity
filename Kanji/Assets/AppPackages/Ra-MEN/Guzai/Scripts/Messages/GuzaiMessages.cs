using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.Guzai
{
    public class InitGuzai : IGuzaiMessage
    {
        public RectTransform DropArea;

        public InitGuzai(RectTransform dropArea)
        {
            DropArea = dropArea;
        }
    }

    public class GuzaiResetOnRamenRequest : IGuzaiMessage
    {
    }

    public class AllGuzaiResetRequest : IGuzaiMessage
    {
    }
}
