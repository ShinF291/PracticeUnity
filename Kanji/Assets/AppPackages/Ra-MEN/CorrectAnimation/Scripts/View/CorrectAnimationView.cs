using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Common.SoundManager;

namespace RaMen.CorrectAnimation
{
    public class CorrectAnimationView : MonoBehaviour
    {
        [Inject]
        private SoundManager _SoundManager;

        [SerializeField]
        private Image _CorrectImage;

        [SerializeField]
        private Image _IncorrectImage;

        [SerializeField]
        private AudioClip _CorrectSe;

        [SerializeField]
        private AudioClip _IncorrectSe;

       
       public Sequence DoCorrectAnimation()
       {
            return DOTween.Sequence()
                .AppendCallback(() => { ActiveCorrectImage(); })
                .AppendCallback(() => { _SoundManager.PlaySe(_CorrectSe); })
                .AppendInterval(_CorrectSe.length)
                .AppendCallback(() => { HiddenCorrectImage(); });
       }

       public Sequence DoIncorrectAnimation()
       {
            return DOTween.Sequence()
                .AppendCallback(() => { ActiveIncorrectImage(); })
                .AppendCallback(() => { _SoundManager.PlaySe(_IncorrectSe); })
                .AppendInterval(_IncorrectSe.length)
                .AppendCallback(() => { HiddenIncorrectImage(); });
       }

        private void HiddenCorrectImage()
        {
            _CorrectImage.enabled = false;
        }

        private void ActiveCorrectImage()
        {
            _CorrectImage.enabled = true;
        }

        private void HiddenIncorrectImage()
        {
            _IncorrectImage.enabled = false;
        }

        private void ActiveIncorrectImage()
        {
            _IncorrectImage.enabled = true;
        }
    }
}
