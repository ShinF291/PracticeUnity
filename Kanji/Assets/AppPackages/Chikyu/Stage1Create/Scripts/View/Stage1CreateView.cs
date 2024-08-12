using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using MamoriOfChikyu.Meteo;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

namespace MamoriOfChikyu.Stage1Create
{
    public class Stage1CreateView : MonoBehaviour
    {

        private GameObject _MeteoClone;

        private GameObject _UFOClone;

        private GameObject _SatelliteClone;

        private readonly Vector3 _SatelliteVector = new Vector3(100, -10, 0);

        private RectTransform _RectTransform;

        private System.Random _Rand = new System.Random();

        private int _RectTransformX;

        private int _RectTransformY;

        private int _XorY;

        private const int CANVAS_SIZE_X = 800;

        private const int CANVAS_SIZE_Y = 600;

        private const int _HalfCanvasSizeX = CANVAS_SIZE_X / 2 ;

        private const int _HalfCanvasSizeY = CANVAS_SIZE_Y / 2 ;

        private const float Z_ZERO = 0.0f;

        private const int RANDOM_MIN_VALUE = 0;

        private const int RANDOM_MAX_VALUE = 4;

        [Inject] 
        private DiContainer _DiContainer;

        public void CreateUFOSeries(CharacterData ufoData, UnityAction ufoGetMessageAction)
        {
            UfoDatas data = new UfoDatas(ufoGetMessageAction);

            CreateCharacter(ufoData, ref _UFOClone);

            MoveUFOClone();

            InitCharacter( data, ref _UFOClone);
        }

        public void CreateMeteoSeries(CharacterData MeteoData, UnityAction<int> PublishChikyuDamage)
        {
            MeteoDatas data = new MeteoDatas(PublishChikyuDamage, MeteoData.Speed, MeteoData.Atk);

            CreateCharacter(MeteoData, ref _MeteoClone);

            MoveMeteoClone();

            InitCharacter( data, ref _MeteoClone);
        }

        public void CreateSatelliteSeries(CharacterData SatelliteData, UnityAction SatelliteDestroyedMessageAction)
        {
            SatelliteDatas data = new SatelliteDatas(SatelliteDestroyedMessageAction, SatelliteData.Speed);

            CreateCharacter(SatelliteData, ref _SatelliteClone);

            MoveSatelliteClone();

            InitCharacter( data, ref _SatelliteClone);
        }

        public void CreateMeteoSeriesNotRandom(CharacterData MeteoData, Vector3 UFOPosition, UnityAction<int> PublishChikyuDamage)
        {
            MeteoDatas data = new MeteoDatas(PublishChikyuDamage, MeteoData.Speed, MeteoData.Atk);

            CreateCharacter(MeteoData, ref _MeteoClone);

            MoveMeteoCloneNotRandom(UFOPosition);

            InitCharacter( data, ref _MeteoClone);
        }

        public void StopSatellite()
        {
            if(_SatelliteClone != null)
            {
                _SatelliteClone.GetComponent<SatellitePresenter>().StopSatelliteMove();
            }
        }

        private void MoveUFOClone()
        {
            RandomRectTransform();
            
            _RectTransform = _UFOClone.transform as RectTransform;
            _RectTransform.localPosition += new Vector3(_RectTransformX, _RectTransformY, Z_ZERO);

            Debug.Log($"UFO move {_RectTransform.localPosition}");
        }

        private void CreateCharacter(CharacterData characterData, ref GameObject clone)
        {
            var _ParentTransform = this.transform;

            clone = _DiContainer.InstantiatePrefab(characterData.CharacterPrefab, _ParentTransform);
        }

        private void InitCharacter<T>(T datas, ref GameObject clone) where T : Datas
        {
            clone.GetComponent<CharacterPresenter<T>>().Init(datas);
        }
 

        private void MoveMeteoClone()
        {
            RandomRectTransform();
            FrameRectTransform();
            
            _RectTransform = _MeteoClone.transform as RectTransform;
            _RectTransform.localPosition += new Vector3(_RectTransformX, _RectTransformY, Z_ZERO);

            Debug.Log($"Meteo move {_RectTransform.localPosition}");
        }

        private void MoveMeteoCloneNotRandom(Vector3 _UFOPosition)
        {
            _RectTransform = _MeteoClone.transform as RectTransform;
            _UFOPosition.z = Z_ZERO;
            _RectTransform.localPosition += _UFOPosition;

            Debug.Log($"Meteo move {_RectTransform.localPosition}");
        }

        private void RandomRectTransform()
        {
            _RectTransformX = _Rand.Next(-_HalfCanvasSizeX, _HalfCanvasSizeX);

            _RectTransformY = _Rand.Next(-_HalfCanvasSizeY, _HalfCanvasSizeY);
        }

        private void FrameRectTransform()
        {
            _XorY = _Rand.Next(RANDOM_MIN_VALUE, RANDOM_MAX_VALUE);

            switch (_XorY)
            {
                case 0: 
                    _RectTransformX = _HalfCanvasSizeX;
                    break;
                case 1:
                    _RectTransformX = -_HalfCanvasSizeX;
                    break;
                case 2:
                    _RectTransformY = _HalfCanvasSizeY;
                    break;
                case 3:
                    _RectTransformY = -_HalfCanvasSizeY;
                    break;
            }
        }

        private void MoveSatelliteClone()
        {    
            _RectTransform = _SatelliteClone.transform as RectTransform;
            _RectTransform.localPosition += _SatelliteVector;
        }
    }
}
