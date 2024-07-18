using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace RaMen.AnswerJudgment
{
    public class AnswerJudgmentController : MonoBehaviour
    {
        [Inject]
        private AnswerJudgmentMessageBroker _AnswerJudgmentMessageBroker;

        [Inject]
        private AnswerJudgmentService _AnswerJudgmentService;

        void Awake()
        {
            _AnswerJudgmentMessageBroker.Receive<AnswerJudgeRequest>()
            .Subscribe(_=>{
                var JudgeResult = _AnswerJudgmentService.JudgeCorrectThisAnswer(_.UsersGuzaiList, _.AnswersGuzaiList, _.UserRelativePoint, _.AnswerRelativePoint, _.Difference);
                _AnswerJudgmentMessageBroker.Publish(new AnswerJudgeResponse(JudgeResult));
            })
            .AddTo(this);
        }

    }
}
