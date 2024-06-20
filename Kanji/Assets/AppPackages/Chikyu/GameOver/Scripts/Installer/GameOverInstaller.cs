using UnityEngine;
using Zenject;

namespace MamoriOfChikyu.GameOver
{
    public class GameOverInstaller : MonoInstaller
    {
        [SerializeField]
        private GameOverPresenter _GameOverPresenter;

        [SerializeField]
        private GameOverView _GameOverView;

        public override void InstallBindings()
        {
            Container.Bind<GameOverMessageBroker>().AsSingle();

            Container.Bind<GameOverPresenter>().FromComponentOn(_GameOverPresenter.gameObject).AsSingle();

            Container.Bind<GameOverView>().FromComponentOn(_GameOverView.gameObject).AsSingle();
            
        }
    }
}