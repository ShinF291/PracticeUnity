using UnityEngine;
using Zenject;

namespace RaMen.StartCountDown
{
    public class StartCountDownInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StartCountDownMessageBroker>().AsSingle();
            
        }
    }
}
