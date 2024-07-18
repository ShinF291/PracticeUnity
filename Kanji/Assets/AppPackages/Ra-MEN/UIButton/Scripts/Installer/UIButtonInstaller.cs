using UnityEngine;
using Zenject;

namespace RaMen.UIButton
{
    public class UIButtonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UIButtonMessageBroker>().AsSingle();
            
        }
    }
}

