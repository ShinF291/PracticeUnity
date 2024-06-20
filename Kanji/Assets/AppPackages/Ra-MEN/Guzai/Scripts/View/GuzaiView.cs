using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Zenject;

namespace RaMen.Guzai
{
    public class GuzaiView: MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [Inject] 
        private DiContainer _DiContainer;

        private RectTransform _DropArea = null;
        private bool _MoveCopyObj = true;
        private GameObject _CopyObj = null;

        private readonly int ARRAY_LENGTH = 4;
        private readonly float ZERO_POSITION = 0;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_MoveCopyObj)
            {
                GameObject target = eventData.pointerDrag;
                _CopyObj = CopyObj(target);
                _MoveCopyObj = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 vec = Camera.main.WorldToScreenPoint(transform.position);
            vec.x += eventData.delta.x;
            vec.y += eventData.delta.y;
            transform.position = Camera.main.ScreenToWorldPoint(vec);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            bool isSuccess = false;
            if (Contains(_DropArea, eventData)) ///
            {
                isSuccess = true;
            }
            
            // 指定領域外
            if (!isSuccess) DestroyMe();

        }

        public void SetDropArea(RectTransform dropArea)
        {
            _DropArea = dropArea;
        }

        public void DestroyCopy()
        {
            if (_MoveCopyObj)
            {
                DestroyMe();
            }
        }

        public void DestroyMe()
        {
            Destroy(this.gameObject);
        }

        // targetがareaの範囲内にいるかどうかを判定する
        private bool Contains(RectTransform area, PointerEventData target)
        {
            var selfBounds = GetBounds(area);
            var worldPos = Vector3.zero;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                area,
                target.position,
                target.pressEventCamera,
                out worldPos);
            worldPos.z = ZERO_POSITION;
            return selfBounds.Contains(worldPos);
        }

        private Bounds GetBounds(RectTransform target)
        {
            Vector3[] Corners = new Vector3[ARRAY_LENGTH];
            var min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            var max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            target.GetWorldCorners(Corners);
            for (var index = 0; index < ARRAY_LENGTH; ++index)
            {
                min = Vector3.Min(Corners[index], min);
                max = Vector3.Max(Corners[index], max);
            }

            max.z = ZERO_POSITION;
            min.z = ZERO_POSITION;

            Bounds bounds = new Bounds(min, Vector3.zero);
            bounds.Encapsulate(max);
            return bounds;
        }

        private GameObject CopyObj(GameObject source)
        {
            GameObject ret = _DiContainer.InstantiatePrefab(source, source.transform.parent);

            ret.transform.position = source.transform.position;
            ret.transform.localScale = source.transform.localScale;
            return ret;
        }

    }
}