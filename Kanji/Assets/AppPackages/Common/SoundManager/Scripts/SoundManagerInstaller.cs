using UnityEngine;
using Zenject;

namespace Common.SoundManager
{
    public class SoundManagerInstaller : MonoInstaller
    {
        [SerializeField]
        private SoundManager _SoundManagerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<SoundManager>().FromComponentInNewPrefab(_SoundManagerPrefab).AsSingle();            
        }
    }
}

