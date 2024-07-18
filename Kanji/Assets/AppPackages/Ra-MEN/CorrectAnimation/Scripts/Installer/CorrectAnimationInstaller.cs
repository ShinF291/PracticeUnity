using UnityEngine;
using Zenject;

namespace RaMen.CorrectAnimation
{
    public class CorrectAnimationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CorrectAnimationMessageBroker>().AsSingle();
            
        }
    }
}
