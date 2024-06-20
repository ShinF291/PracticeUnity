using UnityEngine;
using Zenject;

namespace MamoriOfChikyu.Score
{
    public class ScoreInstaller : MonoInstaller
    {
        [SerializeField]
        private ScoreController _ScoreController;

        public override void InstallBindings()
        {
            Container.Bind<ScoreMessageBroker>().AsSingle();

            Container.Bind<ScoreModel>().AsSingle();

            Container.Bind<ScoreController>().FromComponentOn(_ScoreController.gameObject).AsSingle();
            
        }
    }
}
