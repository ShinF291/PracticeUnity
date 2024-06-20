using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace MamoriOfChikyu.Player
{
    public class PlayerPresenterForKeyboard : MonoBehaviour,IPlayerPresenter
    {
        [Inject]
        private PlayerModel _PlayerModel;

        [Inject]
        private PlayerMessageBroker _PlayerMessageBroker;

        [SerializeField]
        private PlayerView _PlayerView;

        private readonly int MOUSE_BUTTON_LEFT = 0;
        private readonly int MOUSE_BUTTON_RIGHT = 1;
        private readonly int MOUSE_BUTTON_MIDDLE = 2;

        void Awake()
        {
            Observable.EveryFixedUpdate()
                .Subscribe(_ => 
                {
                    if(Input.anyKey && !Input.GetMouseButton(MOUSE_BUTTON_LEFT)
                     && !Input.GetMouseButton(MOUSE_BUTTON_RIGHT) && !Input.GetMouseButton(MOUSE_BUTTON_MIDDLE)
                     && _PlayerModel.PlayerControlFlag){
                        
                        if (Input.GetKey (KeyCode.W)) {
                            _PlayerView.MoveUpPlayer();
                        }
                        if (Input.GetKey (KeyCode.S)) {
                            _PlayerView.MoveDownPlayer();
                        }
                        if (Input.GetKey(KeyCode.A)) {
                            _PlayerView.MoveLeftPlayer();
                        }
                        if (Input.GetKey (KeyCode.D)) {
                            _PlayerView.MoveRightPlayer();
                        }

                    }
                })
                .AddTo(this);

                _PlayerMessageBroker.Receive<PlayerMoveBeginRequest>()
                .Subscribe(_=>{
                    _PlayerModel.PlayerControlFlag = true;
                })
                .AddTo(this);

                _PlayerMessageBroker.Receive<PlayerMoveForbiddenRequest>()
                .Subscribe(_=>{
                    _PlayerModel.PlayerControlFlag = false;
                })
                .AddTo(this);
        }

    }
}
