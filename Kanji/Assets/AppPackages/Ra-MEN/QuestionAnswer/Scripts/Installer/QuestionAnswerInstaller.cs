using UnityEngine;
using Zenject;

namespace RaMen.QuestionAnswer
{
    public class QuestionAnswerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<QuestionAnswerMessageBroker>().AsSingle();
            
        }
    }
}

