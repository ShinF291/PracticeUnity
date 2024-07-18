using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace RaMen
{
    public class RamenSceneStateManager
    {
        public IReadOnlyReactiveProperty<RamenSceneState> CurrentState => _CurrentState;

        ReactiveProperty<RamenSceneState> _CurrentState = new ReactiveProperty<RamenSceneState>(RamenSceneState.Init);

        public void SetState(RamenSceneState nextState)
        {
            this._CurrentState.Value = nextState;
        }

    }

    public enum RamenSceneState
    {
        Init,
        StartQuestion,
        Play,
        CorrectAnimation,
        Result,

    }
}
