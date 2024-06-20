using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace MamoriOfChikyu.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private Text _UI_BP;

        [SerializeField]
        private Text _UI_UFOScore;

        public void UpdateBP(int chikyusBP)
        {
            _UI_BP.text = chikyusBP.ToString();
        }

        public void UpdateUFOScore(int UFOScore)
        {
            _UI_UFOScore.text = UFOScore.ToString();
        }

    }
}
