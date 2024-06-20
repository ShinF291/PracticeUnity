using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace RaMen.Result
{
    public class ResultPresenter : MonoBehaviour
    {
        [Inject]
        private ResultMessageBroker _ResultMessageBroker;

        [Inject]
        private ResultModel _ResultModel;

        [SerializeField]
        private ResultView _ResultView;

        void Awake()
        {
            _ResultMessageBroker.Receive<ResultRequest>()
            .Subscribe(_=>{
                Debug.Log("リザルト表示");
                
                if(_ResultModel.JudgeHighScoreUpdate(_.Score)) _ResultModel.HighScoreUpdate(_.Score);

                _ResultView.ScoreTextUpdate(_.Score, _ResultModel.getBPHighScore());

                if(_ResultModel.JudgeGameClear(_.Score, _.ClearScore))
                {
                    _ResultView.ChangeGameClearImage();
                }else 
                {
                    _ResultView.ChangeGameOverImage();
                }

                _ResultView.ResultPanelActive();
                
            })
            .AddTo(this);
        }
    }
}