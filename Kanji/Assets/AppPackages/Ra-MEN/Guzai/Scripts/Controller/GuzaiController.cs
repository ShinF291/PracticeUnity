using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace RaMen.Guzai
{
    public class GuzaiController : MonoBehaviour
    {
        [Inject]
        private GuzaiMessageBroker _GuzaiMessageBroker;

        [SerializeField]
        private GuzaiView _GuzaiView;

        void Awake()
        {
            _GuzaiMessageBroker.Receive<InitGuzai>()
            .Subscribe(_=>{
                Debug.Log("_.DropArea"+_.DropArea);
                _GuzaiView.SetDropArea(_.DropArea);
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<GuzaiResetOnRamenRequest>()
            .Subscribe(_=>{
                _GuzaiView.DestroyCopy();
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<AllGuzaiResetRequest>()
            .Subscribe(_=>{
                _GuzaiView.DestroyMe();
            })
            .AddTo(this);
        }
    }
}
