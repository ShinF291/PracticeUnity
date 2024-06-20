using UnityEngine;
using Zenject;

namespace RaMen.GuzaiCreate
{
    public class GuzaiCreateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GuzaiCreateMessageBroker>().AsSingle();
            
        }
    }
}

