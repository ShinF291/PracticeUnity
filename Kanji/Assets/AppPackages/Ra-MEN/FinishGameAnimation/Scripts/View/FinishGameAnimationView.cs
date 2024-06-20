using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;
using UniRx;

namespace RaMen.FinishGameAnimation
{
    public class FinishGameAnimationView : MonoBehaviour
    {
        [SerializeField]
        private Image _FinishGameImage;

        public void HiddenFinishGameImage()
        {
            _FinishGameImage.enabled = false;
        }

        public void ActiveFinishGameImage()
        {
            _FinishGameImage.enabled = true;
        }

    }
}
