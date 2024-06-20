using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using MamoriOfChikyu.GameStartCountDown;
using MamoriOfChikyu.Result;
using MamoriOfChikyu.AudioSourceMessage;
using MamoriOfChikyu.BGM;
using MamoriOfChikyu.GameOver;
using MamoriOfChikyu.Timer;
using MamoriOfChikyu.Score;
using MamoriOfChikyu.Stage1Create;
using MamoriOfChikyu.Player;
using MamoriOfChikyu.Meteo;

public class SceneController : MonoBehaviour
{
    [Inject]
    private GameOverMessageBroker _GameOverMessageBroker;

    [Inject]
    private CountDownTimerMessageBroker _CountDownTimerMessageBroker;

    [Inject]
    private Stage1CreateMessageBroker _Stage1CreateMessageBroker;

    [Inject]
    private ScoreMessageBroker _ScoreMessageBroker;

    [Inject]
    private PlayerMessageBroker _PlayerMessageBroker;

    [Inject]
    private MeteoMessageBroker _MeteoMessageBroker;

    [Inject]
    private GameStartCountDownMessageBroker _GameStartCountDownMessageBroker;

    [Inject]
    private ResultMessageBroker _ResultMessageBroker;

    [Inject]
    private AudioSourceMessageBroker _AudioSourceMessageBroker;

    [Inject]
    private IBGMManager _BGMManager;

    void Awake()
    {
        _BGMManager.ChangeGameBGM();
        _BGMManager.PlayBGM();
        
        _GameStartCountDownMessageBroker.Receive<GameStartCountDownResponse>()
        .Subscribe(_=>
        {
            _CountDownTimerMessageBroker.Publish(new TimerStartRequest());
            _AudioSourceMessageBroker.Publish(new AudioSourceMessageRequestStartWhistle());
            _ScoreMessageBroker.Publish(new ScoreStartRequest());
            _PlayerMessageBroker.Publish(new PlayerMoveBeginRequest());

            // _BGMMessageBroker.Publish(new BGMPlayRequest());
         })
        .AddTo(this);

        _CountDownTimerMessageBroker.Receive<timeOver>()
        .Subscribe(_=>
        { 
            this.FinishMessage();
        })
        .AddTo(this);

        _ScoreMessageBroker.Receive<ScoreExtinct>()
        .Subscribe(_=>
        {
            this.FinishMessage();
        })
        .AddTo(this);

        _GameOverMessageBroker.Receive<GameEndResponse>()
        .Subscribe(_=>{ _ResultMessageBroker.Publish(new ResultRequest(_.BP,_.UFOScore));})
        .AddTo(this);

        _Stage1CreateMessageBroker.Receive<ChikyuDamageRequest>()
        .Subscribe(_=>
        { 
            _ScoreMessageBroker.Publish(new ReduceBP(_.Damage));
        })
        .AddTo(this);

         _Stage1CreateMessageBroker.Receive<UfoGet>()
        .Subscribe(_=>
        { 
            _ScoreMessageBroker.Publish(new UFOScoreUPRequest());
        })
        .AddTo(this);


        _ScoreMessageBroker.Receive<ScoreGetResponse>()
        .Subscribe(_=>
        { 
            _GameOverMessageBroker.Publish(new GameEndRequest(_.BP,_.UFOScore));
        })
        .AddTo(this);

        _CountDownTimerMessageBroker.Receive<TimeStep>()
        .Subscribe(_=>
        { 
            _Stage1CreateMessageBroker.Publish(new AddTime());
        })
        .AddTo(this);
    }

    void Start()
    {
        //カウントダウンを始めるイベント
        _GameStartCountDownMessageBroker.Publish(new GameStartCountDownRequest());
    }

    private void FinishMessage()
    {
        _CountDownTimerMessageBroker.Publish(new TimerStopRequest());
        _AudioSourceMessageBroker.Publish(new AudioSourceMessageRequestEndWhistle());
        _ScoreMessageBroker.Publish(new ScoreStopRequest());
        _Stage1CreateMessageBroker.Publish(new StopSatelliteRequest());
        _MeteoMessageBroker.Publish(new MeteoStopRequest());
        _PlayerMessageBroker.Publish(new PlayerMoveForbiddenRequest());
        _ScoreMessageBroker.Publish(new ScoreGetRequest());
    }

}
