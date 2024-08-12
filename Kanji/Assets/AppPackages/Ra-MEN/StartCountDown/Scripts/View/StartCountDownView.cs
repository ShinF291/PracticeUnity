using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using DG.Tweening;
using System.Runtime.CompilerServices;

namespace RaMen.StartCountDown
{
    public class StartCountDownView : MonoBehaviour
    {
        [SerializeField]
        private Image _StartCountDownImage;

        [SerializeField]
        private List<Sprite> _StartCountDownSpriteList;

        private const int ANIMATION_INTERVAL = 1;

        public Sequence CountDownAnimation()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (var sprite in _StartCountDownSpriteList)
            {
                sequence.AppendCallback(() => { _StartCountDownImage.sprite = sprite;});
                sequence.AppendInterval(ANIMATION_INTERVAL);
            }

            return sequence;
        }

        public void HiddenFinishGameImage()
        {
            _StartCountDownImage.enabled = false;
        }

        public void ActiveFinishGameImage()
        {
            _StartCountDownImage.enabled = true;
        }

    }
}
