using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using DG.Tweening;

namespace RaMen.FinishGameAnimation
{
    public class FinishGameAnimationController : MonoBehaviour
    {
        [Inject]
        private FinishGameAnimationMessageBroker _FinishGameAnimationMessageBroker;

        [SerializeField]
        private FinishGameAnimationView _FinishGameAnimationView;

        void Awake()
        {
            _FinishGameAnimationMessageBroker.Receive<FinishGameAnimationRequest>()
            .Subscribe(_=>{
                
                DOTween.Sequence()
                .AppendCallback(() => { _FinishGameAnimationView.ActiveFinishGameImage(); })
                .AppendInterval(1)//音声流す
                .AppendCallback(() => { _FinishGameAnimationMessageBroker.Publish(new FinishGameAnimationResponse()); })
                .Play();
                    
                })
                .AddTo(this);
        }
    }
}