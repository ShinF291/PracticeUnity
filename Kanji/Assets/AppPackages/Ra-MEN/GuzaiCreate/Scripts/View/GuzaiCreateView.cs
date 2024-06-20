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

        [SerializeField]
        private Transform _CreateParent;

        public GameObject CreateGuzaiPrefab(GameObject guzaiPrefab, Transform createPosition)
        {
            GameObject ret =  _DiContainer.InstantiatePrefab(guzaiPrefab, _CreateParent);

            ret.transform.position = createPosition.position;
            ret.transform.localScale = guzaiPrefab.transform.localScale;
            return ret;
        }

    }
}