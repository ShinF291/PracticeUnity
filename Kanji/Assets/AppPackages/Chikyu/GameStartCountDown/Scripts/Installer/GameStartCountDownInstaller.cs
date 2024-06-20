using UnityEngine;
using Zenject;
using MamoriOfChikyu.GameStartCountDown;

public class GameStartCountDownInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameStartCountDownMessageBroker>().AsSingle();
        
    }
}
