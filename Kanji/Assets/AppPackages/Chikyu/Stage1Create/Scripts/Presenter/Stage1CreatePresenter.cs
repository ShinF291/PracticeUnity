using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using Zenject;
using MamoriOfChikyu.Meteo;
using UnityEngine.Events;

namespace MamoriOfChikyu.Stage1Create
{
    public class Stage1CreatePresenter : MonoBehaviour
    {
        [Inject]
        private Stage1CreateMessageBroker _Stage1CreateMessageBroker;

        [Inject]
        private MeteoMessageBroker _MeteoMessageBroker;

        [Inject]
        private Stage1CreateModel _Stage1CreateModel;

        [SerializeField]
        private Stage1CreateView _Stage1CreateView;
        
        void Awake()
        {
            _Stage1CreateModel.Init();

            _Stage1CreateMessageBroker.Receive<StopSatelliteRequest>()
            .Subscribe(_=>{ StopSatellite(); })
            .AddTo(this);

            _MeteoMessageBroker.Receive<UfoListAdd>()
            .Subscribe(_=>{ _Stage1CreateModel.UFOPositionList.Add(_.UfoVec); })
            .AddTo(this);

            _MeteoMessageBroker.Receive<UfoListRemove>()
            .Subscribe(_=>{ _Stage1CreateModel.UFOPositionList.Remove(_.UfoVec); })
            .AddTo(this);

            _Stage1CreateMessageBroker.Receive<AddTime>()
            .Subscribe(_=>{ _Stage1CreateModel.CountTime(); })
            .AddTo(this);

            _Stage1CreateModel.CreateTimeCount
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                _Stage1CreateModel.UpMeteoCreateSpeed();
            })
            .AddTo(this);

            _Stage1CreateModel.CreateTimeCount
            .SkipLatestValueOnSubscribe()
            .Where(_=> _Stage1CreateModel.JudgeUfoCreate())
            .Subscribe(_ =>
            {
                _Stage1CreateView.CreateUFOSeries(_Stage1CreateModel.GetUfoData(), () => _Stage1CreateMessageBroker.Publish(new UfoGet()));
            })
            .AddTo(this);

            _Stage1CreateModel.CreateTimeCount
            .SkipLatestValueOnSubscribe()
            .Where(_=> _Stage1CreateModel.JudgeMeteoCreate())
            .Subscribe(_ =>
            {
                _Stage1CreateView.CreateMeteoSeries(_Stage1CreateModel.GetMeteoData(), PublishChikyuDamage);
            })
            .AddTo(this);

            _Stage1CreateModel.CreateTimeCount
            .SkipLatestValueOnSubscribe()
            .Where(_=> _Stage1CreateModel.JudgeMeteo2Create())
            .Subscribe(_ =>
            {
                _Stage1CreateView.CreateMeteoSeries(_Stage1CreateModel.GetMeteo2Data(), PublishChikyuDamage);
            })
            .AddTo(this);

            _Stage1CreateModel.CreateTimeCount
            .SkipLatestValueOnSubscribe()
            .Where(_=> _Stage1CreateModel.JudgeSatelliteCreate())
            .Subscribe(_ =>
            {
                _Stage1CreateView.CreateSatelliteSeries(_Stage1CreateModel.GetSatalleteData(), PublishSatelliteDestroyed);
                _Stage1CreateModel.SatelliteExist = true;
            })
            .AddTo(this);

            _Stage1CreateModel.CreateTimeCount
            .SkipLatestValueOnSubscribe()
            .Where(_=> _Stage1CreateModel.JudgeTakoCreate())
            .Subscribe(_ =>
            {
                _Stage1CreateModel.UFOPositionList.ForEach(UFOPosition =>
                {
                    Debug.Log($"UFO Position {UFOPosition}");
                    _Stage1CreateView.CreateMeteoSeriesNotRandom(_Stage1CreateModel.GetMeteoTakoData(), UFOPosition, PublishChikyuDamage);
                }
                );
            })
            .AddTo(this);

        }
        private void StopSatellite()
        {
            _Stage1CreateView.StopSatellite();
        }

        private void PublishChikyuDamage (int damage)
        {    
            _Stage1CreateMessageBroker.Publish(new ChikyuDamageRequest(damage));
        }

        private void PublishSatelliteDestroyed ()
        {    
            _Stage1CreateModel.SatelliteExist = false;
        }

    }
}
