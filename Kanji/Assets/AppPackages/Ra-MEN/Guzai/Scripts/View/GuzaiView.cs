using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Zenject;
using UnityEngine.Events;

namespace RaMen.Guzai
{
    public class GuzaiView: MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [Inject] 
        private DiContainer _DiContainer;

        private RectTransform _DropArea = null;
        public bool FirstObj = true;
        private GameObject _CopyObj = null;

        private readonly int ARRAY_LENGTH = 4;
        private readonly float ZERO_POSITION = 0;
        private UnityAction _AddAction;
        private UnityAction _DelAction;

        public bool UsersObj = true;
        public bool UnlockObj = false;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (this.CanDragObj())
            {
                GameObject target = eventData.pointerDrag;
                _CopyObj = CopyObj(target);
                this._AddAction.Invoke();
                FirstObj = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (UsersObj)
            {
                Vector3 vec = Camera.main.WorldToScreenPoint(transform.position);
                vec.x += eventData.delta.x;
                vec.y += eventData.delta.y;
                transform.position = Camera.main.ScreenToWorldPoint(vec);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (UsersObj)
            {
                if (Contains(_DropArea, eventData))
                {
                    

                }else{ 
                    DestroyCopy(); 
                }
            }

        }

        public void SetDropArea(RectTransform dropArea)
        {
            _DropArea = dropArea;
        }

        public void SetAction(UnityAction addAction, UnityAction delAction)
        {
            _AddAction = addAction;
            _DelAction = delAction;
        }

        public void DestroyCopy()
        {
            if (!FirstObj && UsersObj)
            {
                this._DelAction.Invoke();
                DestroyMe();
            }
        }

        public void DestroyAnswer()
        {
            if (!UsersObj)
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

        private bool CanDragObj()
        {
            return FirstObj && UsersObj && UnlockObj;
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
            ret.GetComponent<GuzaiView>().UnlockObj = true;
            ret.GetComponent<GuzaiView>().SetDropArea(_DropArea);
            ret.GetComponent<GuzaiView>().SetAction(_AddAction, _DelAction);
            return ret;
        }

        public void InitAnswerGuzai()
        {
            UsersObj = false;
            FirstObj = false;
        }

    }
}