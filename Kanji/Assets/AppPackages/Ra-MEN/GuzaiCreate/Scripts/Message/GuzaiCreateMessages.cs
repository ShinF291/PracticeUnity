using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.GuzaiCreate
{
    public class GuzaiCreateRequest : IGuzaiCreateMessage
    {
    }

    public class GuzaiCreateResponse : IGuzaiCreateMessage
    {
        public RectTransform DropArea;

        public GuzaiCreateResponse(RectTransform dropArea)
        {
            DropArea = dropArea;
        }
    }

}
