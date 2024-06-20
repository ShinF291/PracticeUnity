// using UnityEngine;
// using Zenject;
// using TypedMessageBroker.Examples;

// public class SampleMonoInstaller : MonoInstaller
// {
//     public override void InstallBindings()
//     {
//         Container.Bind<hogehogeMessageBroker>().AsSingle();

//         Container.Bind<gameMessageBroker>().AsSingle();

//         Container.Bind<gameStartMessageBroker>().AsSingle();

//         Container.Bind<gameEndMessageBroker>().AsSingle();
        
//     }
// }