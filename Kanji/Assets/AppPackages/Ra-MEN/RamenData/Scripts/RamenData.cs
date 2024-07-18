using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaMen.RamenData
{
[CreateAssetMenu(menuName = "ScriptableObject/Create RamenData", fileName="RamenData")]
    public class RamenData : ScriptableObject
    {
        public int Time = 30;

        public int ClearScore = 3;

        public int AnswerGuzai = 3;

        public float PositionDifference = 1;
        
    }
}
