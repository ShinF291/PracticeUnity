using UnityEngine;
using Zenject;

namespace RaMen.Result
{
    public class ResultInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ResultMessageBroker>().AsSingle();

            Container.Bind<ResultModel>().AsSingle();
            
        }
    }
}
