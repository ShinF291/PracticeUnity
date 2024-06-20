using UnityEngine;
using Zenject;
using MamoriOfChikyu.Result;

public class ResultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ResultMessageBroker>().AsSingle();
        
    }
}
