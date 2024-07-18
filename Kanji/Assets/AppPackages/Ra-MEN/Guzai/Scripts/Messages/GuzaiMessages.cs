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

    public class GetGuzaiDataRequest : IGuzaiMessage
    {
    }

    public class GetGuzaiDataResponse : IGuzaiMessage
    {
        public Transform GuzaiPosition;
        public int GuzaiId;
        public bool UsersObj;
        public int MoveObjCount;

        public GetGuzaiDataResponse(Transform guzaiPosition, int guzaiId, bool usersObj, int moveObjCount)
        {
            GuzaiPosition = guzaiPosition;
            GuzaiId = guzaiId;
            UsersObj = usersObj;
            MoveObjCount = moveObjCount;
        }
    }

    public class GuzaiResetOnRamenRequest : IGuzaiMessage
    {
    }

    public class GuzaiResetAnswerRequest : IGuzaiMessage
    {
    }

    public class AllGuzaiResetRequest : IGuzaiMessage
    {
    }

    public class GuzaiForbiddenTouchRequest : IGuzaiMessage
    {
    }

    public class GuzaiUnlockedTouchRequest : IGuzaiMessage
    {
    }
}
