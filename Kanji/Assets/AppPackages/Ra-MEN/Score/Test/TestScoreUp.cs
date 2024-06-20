using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace RaMen.Score.Test
{
public class TestScoreUp : MonoBehaviour
{
    [SerializeField]
    private Button _ScoreUpButton;

    [Inject]
    private ScoreMessageBroker _ScoreMessageBroker;

    void Awake()
    {
        _ScoreUpButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            _ScoreMessageBroker.Publish(new ScoreUPRequest());
        })
        .AddTo(this);
    }
}
}
