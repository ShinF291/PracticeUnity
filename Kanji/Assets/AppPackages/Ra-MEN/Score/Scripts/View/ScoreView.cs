using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace RaMen.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private Text _Score;

        public void UpdateScore(int score)
        {
            _Score.text = score.ToString();
        }

    }
}
