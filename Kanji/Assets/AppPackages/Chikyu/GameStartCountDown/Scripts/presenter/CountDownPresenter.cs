using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using MamoriOfChikyu.GameStartCountDown;

public class CountDownPresenter : MonoBehaviour
{

    [Inject]
    GameStartCountDownMessageBroker _GameStartCountDownMessageBroker;

    [SerializeField]
    GamaStartCountDownModel _GamaStartCountDownModel;

    [SerializeField]
    CountDownView _CountDownView;

    // カウントダウン
    // property.valueが-1になるまで
    private const int COUNT_DOWN_END = -1;

    void Awake()
    {
        //カウントダウンはじめイベント受け取る
        //

        _GamaStartCountDownModel.property
        .SkipLatestValueOnSubscribe()
        .Subscribe(x => {

            if(x <= COUNT_DOWN_END) //ToDo 条件　サービスで
            {
                Debug.Log($"GameStart!!");
                _GamaStartCountDownModel.StopCountDown();
                _CountDownView.CountDownImageNotActive();
                _GameStartCountDownMessageBroker.Publish(new GameStartCountDownResponse());
            }
            else 
            {
                Debug.Log(x);
                _CountDownView.ChangeCountDownImage(x);
            }
            
        })
        .AddTo(this);

        _GameStartCountDownMessageBroker.Receive<GameStartCountDownRequest>()
        .Subscribe(_=>{
            Debug.Log($"CountDownStart");
            _GamaStartCountDownModel.StartCountDown();
        })
        .AddTo(this);
    }

}
