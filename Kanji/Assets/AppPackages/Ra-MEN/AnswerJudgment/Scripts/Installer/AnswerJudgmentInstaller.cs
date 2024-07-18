using UnityEngine;
using Zenject;

namespace RaMen.AnswerJudgment
{
    public class AnswerJudgmentInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AnswerJudgmentMessageBroker>().AsSingle();
            
            Container.Bind<AnswerJudgmentService>().AsSingle();
            
        }
    }
}

