using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace RaMen.Score
{
    public class ScoreModel
    {
        public IReadOnlyReactiveProperty<int> RamenScore => _RamenScore;

        ReactiveProperty<int> _RamenScore = new ReactiveProperty<int>();

        private const int INIT_SCORE = 0;
        
        public void Init()
        {
            _RamenScore.Value = INIT_SCORE;
        }

        public int GetRamenScore(){
            return _RamenScore.Value;
        }

        public void IncrementRamenScore(){
            _RamenScore.Value++;
        }

    }
}
