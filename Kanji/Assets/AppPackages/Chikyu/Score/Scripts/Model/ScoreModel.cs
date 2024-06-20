using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace MamoriOfChikyu.Score
{
    public class ScoreModel
    {
        public IReadOnlyReactiveProperty<int> BP => _BP;

        ReactiveProperty<int> _BP = new ReactiveProperty<int>();

        public IReadOnlyReactiveProperty<int> UFOScore => _UFOScore;

        ReactiveProperty<int> _UFOScore = new ReactiveProperty<int>();

        private int _UpdateCount;

        private bool _ScoreAdd;
        
        public void Init()
        {
            _BP.Value = 50;
            _UFOScore.Value = 0;
            _UpdateCount = 0;
            _ScoreAdd = false;
        }

        public int UpdateCount { 
            get { return _UpdateCount; }
            set { _UpdateCount = value; }
        }

        public bool ScoreAdd { 
            get { return _ScoreAdd; }
            set { _ScoreAdd = value; }
        }

        public int getBP(){
            return _BP.Value;
        }

         public int getUFOScore(){
            return _UFOScore.Value;
        }

        public void SetBP(int AfterBP){
            _BP.Value = AfterBP;
        }

        public void SetUFOScore(int AfterUFOScore){
            _UFOScore.Value = AfterUFOScore;
        }

        public void IncrementBP(){
            _BP.Value++;
        }

        public void IncrementUFOScore(){
            _UFOScore.Value++;
        }

        public void IncrementUpdateCount(){
            _UpdateCount++;
        }

        public bool JudgeBPAdd(){
            return _UpdateCount == 5;
        }

        public void ResetUpdateCount(){
            _UpdateCount = 0;
        }

        public void ReduceBP(int value){
            _BP.Value -= value;
        }

        public bool IsBelowZeroBP(){
            return _BP.Value <= 0;
        }

    }
}
