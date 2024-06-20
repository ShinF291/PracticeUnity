using UnityEngine;
using Zenject;

namespace RaMen.FinishGameAnimation
{
    public class FinishGameAnimationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<FinishGameAnimationMessageBroker>().AsSingle();
            
        }
    }
}
