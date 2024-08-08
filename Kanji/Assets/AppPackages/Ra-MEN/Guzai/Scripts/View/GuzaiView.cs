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

        private Vector3[] _Corners = null;
        private Vector3 _Min;
        private Vector3 _Max;
        private Vector3 _ScreenPoint;

        private Bounds _SelfBounds;
        private Vector3 _WorldPos;

        public bool UsersObj = true;
        public bool UnlockObj = false;
        

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (this.CanDragObj())
            {
                _CopyObj = CopyObj(eventData.pointerDrag);
                this._AddAction.Invoke();
                FirstObj = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (UsersObj)
            {
                _ScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
                _ScreenPoint.x += eventData.delta.x;
                _ScreenPoint.y += eventData.delta.y;
                transform.position = Camera.main.ScreenToWorldPoint(_ScreenPoint);
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
            _SelfBounds = GetBounds(area);

            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                area,
                target.position,
                target.pressEventCamera,
                out _WorldPos);

            _WorldPos.z = ZERO_POSITION;

            return _SelfBounds.Contains(_WorldPos);
        }

        private bool CanDragObj()
        {
            return FirstObj && UsersObj && UnlockObj;
        }
        

        private Bounds GetBounds(RectTransform target)
        {
            _Corners = new Vector3[ARRAY_LENGTH];
            _Min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            _Max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            target.GetWorldCorners(_Corners);
            for (var index = 0; index < ARRAY_LENGTH; ++index)
            {
                _Min = Vector3.Min(_Corners[index], _Min);
                _Max = Vector3.Max(_Corners[index], _Max);
            }

            _Max.z = ZERO_POSITION;
            _Min.z = ZERO_POSITION;

            Bounds bounds = new Bounds(_Min, Vector3.zero);
            bounds.Encapsulate(_Max);
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