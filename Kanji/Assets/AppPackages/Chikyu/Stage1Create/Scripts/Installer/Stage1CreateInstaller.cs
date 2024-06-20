using UnityEngine;
using Zenject;

namespace MamoriOfChikyu.Stage1Create
{
    public class Stage1CreateInstaller : MonoInstaller
    {
        [SerializeField]
        private StageCreateParameter _StageCreateParameter;

        public override void InstallBindings()
        {
            Container.Bind<Stage1CreateMessageBroker>().AsSingle();
            Container.Bind<Stage1CreateModel>().AsSingle();
            Container.Bind<StageCreateParameter>().FromScriptableObject(_StageCreateParameter).AsSingle();          
        }
    }
}


