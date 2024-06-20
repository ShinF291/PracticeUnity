using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using UnityEngine.Events;

namespace MamoriOfChikyu.Meteo
{
    public class UfoPresenter : CharacterPresenter<UfoDatas>
    {
        [Inject]
        private MeteoMessageBroker _MeteoMessageBroker;

        [SerializeField]
        private UfoView _UfoView;

        public override void Init(UfoDatas ufoDatas)
        {
            _UfoView.Init(ufoDatas.UfoGetMessageAction, SendUfoListRemoveMessage);

            var _RectTransform = _UfoView.transform as RectTransform;
            _MeteoMessageBroker.Publish(new UfoListAdd(_RectTransform.localPosition));
        }

        public void SendUfoListRemoveMessage(Vector3 position)
        {
            _MeteoMessageBroker.Publish(new UfoListRemove(position));
        }
    }

    public class UfoDatas : Datas
    {
        public UnityAction UfoGetMessageAction;

        public UfoDatas(UnityAction ufoGetMessageAction)
        {
            UfoGetMessageAction = ufoGetMessageAction;
        }
    }

}
