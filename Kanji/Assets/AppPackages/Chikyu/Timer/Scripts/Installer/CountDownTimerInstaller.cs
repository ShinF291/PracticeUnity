using UnityEngine;
using Zenject;
using MamoriOfChikyu.Result;

namespace MamoriOfChikyu.Timer
{
    public class CountDownTimerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CountDownTimerMessageBroker>().AsSingle();
            Container.Bind<CountDownTimerModel>().AsSingle();
            
        }
    }
}

