using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace RaMen.UIButton
{
    public class UIButtonController : MonoBehaviour
    {
        [Inject]
        private UIButtonMessageBroker _UIButtonMessageBroker;

        [SerializeField]
        private Button _AnswerButton;

        [SerializeField]
        private Button _ResetButton;

        void Awake()
        {
            _AnswerButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _UIButtonMessageBroker.Publish(new AnswerButtonPushed());
            })
            .AddTo(this);

            _ResetButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _UIButtonMessageBroker.Publish(new ResetButtonPushed());
            })
            .AddTo(this);
        }
    }
}
