using UnityEngine;
using Zenject;

namespace Common.Timer
{
    public class TimerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TimerMessageBroker>().AsSingle();
            
            Container.Bind<TimerModel>().AsSingle();
            
        }
    }
}

