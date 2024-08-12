using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Zenject;

namespace RaMen.GuzaiCreate
{
    public class GuzaiCreateView: MonoBehaviour
    {
        [Inject] 
        private DiContainer _DiContainer;

        [SerializeField]
        public RectTransform DropArea = null;

        private GameObject _Obj;

        public void CreateGuzaiPrefab(GameObject guzaiPrefab, Transform createPosition)
        {
            _Obj = _DiContainer.InstantiatePrefab(guzaiPrefab, createPosition);

            _Obj.transform.position = createPosition.position;
            _Obj.transform.localScale = guzaiPrefab.transform.localScale;
        }

    }
}