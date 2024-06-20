using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using MamoriOfChikyu.Result;

public class ResultPresenter : MonoBehaviour
{

    [Inject]
    ResultMessageBroker _ResultMessageBroker;

    [SerializeField]
    ResultView _ResultView;

    [SerializeField]
    Button _RestartButton;//ToDo　viewへ

    void Awake()
    {
        _RestartButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            ChangeToTapScene();

        })
        .AddTo(this);
       

        _ResultMessageBroker.Receive<ResultRequest>()
        .Subscribe(_=>{
            Debug.Log($"DispResult");

            ActiveView();

            ScoreUpdate(_.BP, _.UFOScore);
            
        })
        .AddTo(this);
    }


    private void ActiveView()
    {
        _ResultView.ResultActive();
    }

    private void ScoreUpdate(int bp, int ufoScore)
    {
        _ResultView.ScoreUpdate(bp,ufoScore);
    }

    private void ChangeToTapScene()
    {
        _RestartButton.interactable = false;
        _ResultView.ChangeToTapScene();
    }
   

}