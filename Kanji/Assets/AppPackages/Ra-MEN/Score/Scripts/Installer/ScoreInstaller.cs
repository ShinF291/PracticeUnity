using UnityEngine;
using Zenject;

namespace RaMen.Score
{
    public class ScoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ScoreMessageBroker>().AsSingle();

            Container.Bind<ScoreModel>().AsSingle();
            
        }
    }
}
