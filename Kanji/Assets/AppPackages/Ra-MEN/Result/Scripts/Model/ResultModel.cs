using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RaMen.Result
{
    public class ResultModel
    {
        private int _HighScore = 0;

        private readonly string SAVE_KEY = "RamenHighScore";

        private readonly int DEFAULT_HIGH_SCORE = 0;

        void Awake()
        {
            _HighScore = PlayerPrefs.GetInt (SAVE_KEY, DEFAULT_HIGH_SCORE);
        }

        public int getBPHighScore()
        {
            return _HighScore;
        }

        public bool JudgeHighScoreUpdate(int thisTimeScore)
        {
            return thisTimeScore > _HighScore;
        }

        public void HighScoreUpdate(int thisTimeScore)
        {
            _HighScore = thisTimeScore;
            PlayerPrefs.SetInt(SAVE_KEY, _HighScore);
            PlayerPrefs.Save();
        }

        public bool JudgeGameClear(int thisTimeScore, int clearScore)
        {
            return thisTimeScore >= clearScore;
        }
        
    }
}