using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace MamoriOfChikyu.Player
{
    public class PlayerView : MonoBehaviour
    {

        [SerializeField]
        private float speed = 0.02f;

        private bool _PlayerControlFlag = false;

        private Vector2 Position;

        void Awake()
        {
            Observable.EveryFixedUpdate()
                .Subscribe(_ => 
                {
                    if(Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && _PlayerControlFlag){
                        Position = transform.position;
                        
                        if (Input.GetKey (KeyCode.W)) {
                            Position.y += speed;
                        }
                        if (Input.GetKey (KeyCode.S)) {
                            Position.y -= speed;
                        }
                        if (Input.GetKey(KeyCode.A)) {
                            Position.x -= speed;
                        }
                        if (Input.GetKey (KeyCode.D)) {
                            Position.x += speed;
                        }

                        transform.position = Position;
                    }
                })
                .AddTo(this);
        }

        public void MoveUpPlayer()
        {
            Position = transform.position;
            Position.y += speed;
            this.transform.position = Position;
        }

        public void MoveDownPlayer()
        {
            Position = transform.position;
            Position.y -= speed;
            this.transform.position = Position;
        }

        public void MoveLeftPlayer()
        {
            Position = transform.position;
            Position.x -= speed;
            this.transform.position = Position;
        }

        public void MoveRightPlayer()
        {
            Position = transform.position;
            Position.x += speed;
            this.transform.position = Position;
        }

        public void SwitchCanControlPlayer()
        {
            _PlayerControlFlag = true;
        }

        public void SwitchCanNotControlPlayer()
        {
            _PlayerControlFlag = false;
        }

    }
}
