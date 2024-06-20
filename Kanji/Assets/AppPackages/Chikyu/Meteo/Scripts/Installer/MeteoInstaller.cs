using UnityEngine;
using Zenject;

namespace MamoriOfChikyu.Meteo
{
    public class MeteoInstaller : MonoInstaller
    {
        [SerializeField]
        private CharaDataList _CharaDataList;

        public override void InstallBindings()
        {
            Container.Bind<MeteoMessageBroker>().AsSingle();

            Container.Bind<CharaDataList>().FromScriptableObject(_CharaDataList).AsSingle();
            
        }
    }
}
