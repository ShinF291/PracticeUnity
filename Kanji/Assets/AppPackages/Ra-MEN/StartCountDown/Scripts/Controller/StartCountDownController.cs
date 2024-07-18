using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using DG.Tweening;

namespace RaMen.StartCountDown
{
    public class StartCountDownController : MonoBehaviour
    {
        [Inject]
        private StartCountDownMessageBroker _StartCountDownMessageBroker;

        [SerializeField]
        private StartCountDownView _StartCountDownView;

        void Awake()
        {
            _StartCountDownMessageBroker.Receive<StartCountDownRequest>()
            .Subscribe(_=>{
                DOTween.Sequence()
                .AppendCallback(() => { _StartCountDownView.ActiveFinishGameImage(); })
                .Append(_StartCountDownView.CountDownAnimation())
                .AppendCallback(() => { _StartCountDownView.HiddenFinishGameImage(); })
                .AppendCallback(() => { _StartCountDownMessageBroker.Publish(new StartCountDownResponse()); })
                .Play();
                
            })
            .AddTo(this);
        }
    }
}
