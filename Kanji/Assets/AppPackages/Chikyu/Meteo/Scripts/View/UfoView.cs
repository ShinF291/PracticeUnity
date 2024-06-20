using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using MamoriOfChikyu.AudioSourceMessage;
using UnityEngine.Events;

namespace MamoriOfChikyu.Meteo
{
    public class UfoView : CharacterView
    {
        [Inject]
        private AudioSourceMessageBroker _AudioSourceMessageBroker;

        private RectTransform _RectTransform;

        public UnityAction<Vector3> UFOPositionListRemove;
        public UnityAction UfoGetMessage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                    UfoGetMessage.Invoke();
                    var _RectTransform = this.transform as RectTransform;
                    UFOPositionListRemove.Invoke(_RectTransform.localPosition);
                    _AudioSourceMessageBroker.Publish(new AudioSourceMessageRequestUfoGet());
                    Destroy(this.gameObject);
            }

            if (collision.tag == "Chikyu")
            {
                    var _RectTransform = this.transform as RectTransform;
                    UFOPositionListRemove.Invoke(_RectTransform.localPosition);
                    Destroy( this.gameObject );
            }
        }

        public void Init(UnityAction ufoGetMessageAction, 
                        UnityAction<Vector3> uFOPositionListRemoveAction)
        {
            UfoGetMessage = ufoGetMessageAction;
            UFOPositionListRemove = uFOPositionListRemoveAction;

            //座標を設定
            //アクティブ非アクティブをみるリアクティブプロパティ
        }


}
}

