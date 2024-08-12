using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using RaMen.Guzai;

namespace RaMen.QuestionAnswer
{
    public class QuestionAnswerController : MonoBehaviour
    {
        [Inject]
        private QuestionAnswerMessageBroker _QuestionAnswerMessageBroker;

        [Inject]
        private UseGuzaiList _UseGuzaiList;

        [SerializeField]
        private QuestionAnswerView _QuestionAnswerView;

        [SerializeField]
        private List<Transform> _CreateParent;

        private const int ARRAY_LENGTH = 4;

        void Awake()
        {
            _QuestionAnswerMessageBroker.Receive<QuestionAnswerCreateRequest>()
            .Subscribe(_=>{
                for (int i = 0; i < _.Number; i++)
                {
                    Vector3[] Corners = new Vector3[ARRAY_LENGTH];
                    _QuestionAnswerView.QuestionArea.GetWorldCorners(Corners);

                    float x = Random.Range(Corners[0].x, Corners[2].x);
                    float y = Random.Range(Corners[0].y, Corners[2].y);
                    int guzai = Random.Range(0, _UseGuzaiList.UseGuzaiPrehab.Count);
                    _QuestionAnswerView.CreateQuestionAnswerGuzaiPrefab(_UseGuzaiList.UseGuzaiPrehab[guzai].gameObject, new Vector3(x,y,0), _CreateParent[guzai])
                    .GetComponent<GuzaiView>().InitAnswerGuzai();
                }

                _QuestionAnswerMessageBroker.Publish(new QuestionAnswerCreateResponse());
                
            })
            .AddTo(this);

            _QuestionAnswerMessageBroker.Receive<GetRelativePointRequest>()
            .Subscribe(_=>{
                _QuestionAnswerMessageBroker.Publish(new GetRelativePointResponse(_QuestionAnswerView.UserRelativePoint, _QuestionAnswerView.AnswerRelativePoint));
            })
            .AddTo(this);
        }
    }
}
