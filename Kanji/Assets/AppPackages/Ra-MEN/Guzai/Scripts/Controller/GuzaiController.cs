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

        [Inject]
        private GuzaiModel _GuzaiModel;

        [SerializeField]
        private GuzaiView _GuzaiView;

        [SerializeField]
        private int _GuzaiId;

        void Awake()
        {
            _GuzaiMessageBroker.Receive<InitGuzai>()
            .Subscribe(_=>{
                _GuzaiView.SetDropArea(_.DropArea);
                _GuzaiView.SetAction(AddCountGuzai, DelCountGuzai);
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<GetGuzaiDataRequest>()
            .Subscribe(_=>{
                if(!_GuzaiView.FirstObj)
                {
                    _GuzaiMessageBroker.Publish(new GetGuzaiDataResponse(this.transform, _GuzaiId, _GuzaiView.UsersObj, _GuzaiModel.MoveObjCount));
                }
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<GuzaiResetOnRamenRequest>()
            .Subscribe(_=>{
                _GuzaiView.DestroyCopy();
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<GuzaiResetAnswerRequest>()
            .Subscribe(_=>{
                _GuzaiView.DestroyAnswer();
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<AllGuzaiResetRequest>()
            .Subscribe(_=>{
                _GuzaiView.DestroyMe();
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<GuzaiForbiddenTouchRequest>()
            .Subscribe(_=>{
                _GuzaiView.UnlockObj = false;
            })
            .AddTo(this);

            _GuzaiMessageBroker.Receive<GuzaiUnlockedTouchRequest>()
            .Subscribe(_=>{
                _GuzaiView.UnlockObj = true;
            })
            .AddTo(this);
        }

        private void AddCountGuzai()
        {
            _GuzaiModel.MoveObjCount++;
        }

        private void DelCountGuzai()
        {
            _GuzaiModel.MoveObjCount--;
        }
    }
}
