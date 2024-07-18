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
        private Transform _CreateParent;

        [SerializeField]
        public RectTransform QuestionArea;

        [SerializeField]
        public Transform UserRelativePoint;
        
        [SerializeField]
        public Transform AnswerRelativePoint;

        public GameObject CreateQuestionAnswerGuzaiPrefab(GameObject guzai, Vector3 createPosition)
        {
            GameObject ret =  _DiContainer.InstantiatePrefab(guzai, _CreateParent);

            ret.transform.position = createPosition;
            ret.transform.localScale = guzai.transform.localScale;
            return ret;
        }

    }
}