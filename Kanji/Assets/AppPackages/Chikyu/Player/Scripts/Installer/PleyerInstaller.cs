using UnityEngine;
using Zenject;

namespace MamoriOfChikyu.Player
{
    public class PleyerInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerPresenterForKeyboard _PlayerPresenterForKeyboard;

        public override void InstallBindings()
        {
            Container.Bind<PlayerMessageBroker>().AsSingle();
            Container.Bind<PlayerModel>().AsSingle();

            // Container.Bind<IPlayerPresenter>().FromComponentOn(_PlayerPresenterForKeyboard.gameObject).AsSingle();
            
        }
    }
}

