using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using DG.Tweening;
using Common.SoundManager;

namespace RaMen.FinishGameAnimation
{
    public class FinishGameAnimationController : MonoBehaviour
    {
        [Inject]
        private SoundManager _SoundManager;

        [Inject]
        private FinishGameAnimationMessageBroker _FinishGameAnimationMessageBroker;

        [SerializeField]
        private FinishGameAnimationView _FinishGameAnimationView;

        [SerializeField]
        private AudioClip _FinishSe;

        void Awake()
        {
            _FinishGameAnimationMessageBroker.Receive<FinishGameAnimationRequest>()
            .Subscribe(_=>{
                
                DOTween.Sequence()
                .AppendCallback(() => { _FinishGameAnimationView.ActiveFinishGameImage(); })
                .AppendCallback(() => { _SoundManager.PlaySe(_FinishSe); })
                .AppendInterval(_FinishSe.length)
                .AppendCallback(() => { _FinishGameAnimationMessageBroker.Publish(new FinishGameAnimationResponse()); })
                .Play();
                    
                })
                .AddTo(this);
        }
    }
}