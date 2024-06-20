using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using MamoriOfChikyu.Meteo;

namespace MamoriOfChikyu.Stage1Create
{
    public class Stage1CreateModel
    {
        public IReadOnlyReactiveProperty<int> CreateTimeCount => _CreateTimeCount;
        ReactiveProperty<int> _CreateTimeCount = new ReactiveProperty<int>(0);

        public List<Vector3> UFOPositionList;
        public bool SatelliteExist;

        [Inject]
        private CharaDataList _CharaDataList;

        [Inject]
        private StageCreateParameter _StageCreateParameter;

        private Dictionary<CharacterId, int> _CreateTimeSpanDic;

        private int _MeteoCreateSpeedUpTimeSpan;
        private int _MeteoCreateSpeedUpPhase;
        private int _MeteoCreateSpeedUpSpanShortening;
        private int _Meteo2CreatePhase;
        private int _MeteoCreateSpeedUpCount = 0;

        private const int JUDGE_CONSTANT = 0;
        private const int TAKO_CREATE_UFO_COUNT = 1;

        public void Init()
        {
            UFOPositionList = new List<Vector3>();

            _CreateTimeSpanDic = new Dictionary<CharacterId, int>();

            SatelliteExist = false;

            this.LoadTimeSpan();

            _MeteoCreateSpeedUpTimeSpan = _StageCreateParameter.MeteoCreateSpeedUpTimeSpan;
            _MeteoCreateSpeedUpPhase = _StageCreateParameter.MeteoCreateSpeedUpPhase;
            _MeteoCreateSpeedUpSpanShortening = _StageCreateParameter.MeteoCreateSpeedUpSpanShortening;
            _Meteo2CreatePhase = _StageCreateParameter.LevelUpPhase;
        }

        public void CountTime()
        {
            _CreateTimeCount.Value++;
        }

        public bool JudgeUfoCreate()
        {
            if(_CreateTimeSpanDic.ContainsKey(CharacterId.UFO))
            {
                return _CreateTimeCount.Value % _CreateTimeSpanDic[CharacterId.UFO] == JUDGE_CONSTANT;
            }else
            {
                return false;
            }
            
        }

        public bool JudgeMeteoCreate()
        {
            if(_CreateTimeSpanDic.ContainsKey(CharacterId.METEO))
            {
                return _CreateTimeCount.Value % _CreateTimeSpanDic[CharacterId.METEO] == JUDGE_CONSTANT;
            }else
            {
                return false;
            }

        }

        public bool JudgeMeteo2Create()
        {
            if(_CreateTimeSpanDic.ContainsKey(CharacterId.METEO2))
            {
                return _CreateTimeCount.Value % _CreateTimeSpanDic[CharacterId.METEO2] == JUDGE_CONSTANT && _MeteoCreateSpeedUpCount >= _Meteo2CreatePhase;
            }else
            {
                return false;
            }
        }

        public bool JudgeSatelliteCreate()
        {
            if(_CreateTimeSpanDic.ContainsKey(CharacterId.SATELLITE))
            {
                return _CreateTimeCount.Value % _CreateTimeSpanDic[CharacterId.SATELLITE] == JUDGE_CONSTANT && !SatelliteExist;
            }else
            {
                return false;
            }
        }

        public bool JudgeTakoCreate()
        {
            if(_CreateTimeSpanDic.ContainsKey(CharacterId.METEOTAKO))
            {
                return _CreateTimeCount.Value % _CreateTimeSpanDic[CharacterId.METEOTAKO] == JUDGE_CONSTANT && UFOPositionList.Count >= TAKO_CREATE_UFO_COUNT;
            }else
            {
                return false;
            }
        }

        public void UpMeteoCreateSpeed()
        {
            if(_CreateTimeCount.Value % _MeteoCreateSpeedUpTimeSpan == JUDGE_CONSTANT && _MeteoCreateSpeedUpCount < _MeteoCreateSpeedUpPhase && _CreateTimeSpanDic.ContainsKey(CharacterId.METEO))
            {
                _MeteoCreateSpeedUpCount++;

                _CreateTimeSpanDic[CharacterId.METEO] -= _MeteoCreateSpeedUpSpanShortening;

            }
        }

        public CharacterData GetMeteoData()
        {
            return _CharaDataList.CharacterData.Find(x => x.CharaId == CharacterId.METEO);
        }

        public CharacterData GetMeteo2Data()
        {
            return _CharaDataList.CharacterData.Find(x => x.CharaId == CharacterId.METEO2);
        }

        public CharacterData GetMeteoTakoData()
        {
            return _CharaDataList.CharacterData.Find(x => x.CharaId == CharacterId.METEOTAKO);
        }

        public CharacterData GetUfoData()
        {
            return _CharaDataList.CharacterData.Find(x => x.CharaId == CharacterId.UFO);
        }

        public CharacterData GetSatalleteData()
        {
            return _CharaDataList.CharacterData.Find(x => x.CharaId == CharacterId.SATELLITE);
        }

        private void LoadTimeSpan()
        {
            // リスト分読み込む
            foreach (var characterData in _CharaDataList.CharacterData)
            {
                _CreateTimeSpanDic.Add(characterData.CharaId, characterData.CreateTimeSpan);
            }
           
        }


    }
}
