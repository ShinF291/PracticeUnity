using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MamoriOfChikyu.BGM
{
    public class BGMInstaller : MonoInstaller
    {
        [SerializeField]
        private AudioSource _GameAudioSource;

        [SerializeField]
        private AudioSource _TitleAudioSource;

        public override void InstallBindings()
        {
            Container.Bind<IBGMManager>().To<BGMManager>().AsSingle();

            Container.Bind<AudioSource>().WithId(BGMDefine.GameAudioSource).FromComponentOn(_GameAudioSource.gameObject).AsCached();

            Container.Bind<AudioSource>().WithId(BGMDefine.TitleAudioSource).FromComponentOn(_TitleAudioSource.gameObject).AsCached();
            
        }
    }
}
