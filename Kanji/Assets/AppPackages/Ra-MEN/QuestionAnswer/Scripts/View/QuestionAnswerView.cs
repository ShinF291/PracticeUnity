using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Zenject;

namespace RaMen.QuestionAnswer
{
    public class QuestionAnswerView: MonoBehaviour
    {
        [Inject] 
        private DiContainer _DiContainer;

        [SerializeField]
        public RectTransform QuestionArea;

        [SerializeField]
        public Transform UserRelativePoint;
        
        [SerializeField]
        public Transform AnswerRelativePoint;

        private GameObject _Obj;

        public GameObject CreateQuestionAnswerGuzaiPrefab(GameObject guzai, Vector3 createPosition, Transform createParent)
        {
            _Obj = _DiContainer.InstantiatePrefab(guzai, createParent);

            _Obj.transform.position = createPosition;
            _Obj.transform.localScale = guzai.transform.localScale;
            return _Obj;
        }

    }
}