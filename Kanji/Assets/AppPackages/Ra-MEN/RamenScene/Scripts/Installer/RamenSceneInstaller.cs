using UnityEngine;
using Zenject;

namespace RaMen
{
    public class RamenSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<RamenSceneStateManager>().AsSingle();
            
        }
    }
}


