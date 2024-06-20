using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace RaMen.GuzaiCreate
{
    public class GuzaiCreateController : MonoBehaviour
    {
        [Inject]
        private GuzaiCreateMessageBroker _GuzaiCreateMessageBroker;

        [Inject]
        private UseGuzaiList _UseGuzaiList;

        [SerializeField]
        private GuzaiCreateView _GuzaCreateiView;

        [SerializeField]
        private List<Transform> _CreatePosition;

        void Awake()
        {
            _GuzaiCreateMessageBroker.Receive<GuzaiCreateRequest>()
            .Subscribe(_=>{
                int value = 0;///
                foreach (var guzai in _UseGuzaiList.UseGuzaiPrehab)
                {
                    Debug.Log("guzai : "+guzai);
                    Debug.Log(value+"_CreatePosition : "+_CreatePosition[value]);
                    _GuzaCreateiView.CreateGuzaiPrefab(guzai, _CreatePosition[value]);
                    value++;
                }

                _GuzaiCreateMessageBroker.Publish(new GuzaiCreateResponse(_GuzaCreateiView.DropArea));
                
            })
            .AddTo(this);
        }
    }
}
