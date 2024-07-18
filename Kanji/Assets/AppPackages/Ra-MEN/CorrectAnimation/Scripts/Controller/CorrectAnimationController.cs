using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using DG.Tweening;

namespace RaMen.CorrectAnimation
{
    public class CorrectAnimationController : MonoBehaviour
    {
        [Inject]
        private CorrectAnimationMessageBroker _CorrectAnimationMessageBroker;

        [SerializeField]
        private CorrectAnimationView _CorrectAnimationView;

        void Awake()
        {
            _CorrectAnimationMessageBroker.Receive<CorrectAnimationRequest>()
            .Subscribe(_=>{
                DOTween.Sequence()
                .Append(_CorrectAnimationView.DoCorrectAnimation())
                .AppendCallback(() => { _CorrectAnimationMessageBroker.Publish(new CorrectAnimationResponse()); })
                .Play();
            })
            .AddTo(this);

            _CorrectAnimationMessageBroker.Receive<IncorrectAnimationRequest>()
            .Subscribe(_=>{
                DOTween.Sequence()
                .Append(_CorrectAnimationView.DoIncorrectAnimation())
                .AppendCallback(() => { _CorrectAnimationMessageBroker.Publish(new IncorrectAnimationResponse()); })
                .Play();
            })
            .AddTo(this);
        }
    }
}
