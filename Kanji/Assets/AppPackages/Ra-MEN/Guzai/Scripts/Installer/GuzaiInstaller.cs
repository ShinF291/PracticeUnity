using UnityEngine;
using Zenject;

namespace RaMen.Guzai
{
    public class GuzaiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GuzaiMessageBroker>().AsSingle();
            Container.Bind<GuzaiModel>().AsSingle();
            
        }
    }
}

