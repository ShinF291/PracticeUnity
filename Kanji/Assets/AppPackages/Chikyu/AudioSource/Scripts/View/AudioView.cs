using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using MamoriOfChikyu.AudioSourceMessage;

public class AudioView : MonoBehaviour
{

    [Inject]
    AudioSourceMessageBroker _AudioSourceMessageBroker;

    [SerializeField]
    SE_List _SE_List;

    [SerializeField]
    AudioSource _AudioSource;

    void Awake()
    {
        _AudioSourceMessageBroker.Receive<AudioSourceMessageRequestStartWhistle>()
        .Subscribe(_=>{
            _AudioSource.PlayOneShot(_SE_List._StartWhistle);
        })
        .AddTo(this);

        _AudioSourceMessageBroker.Receive<AudioSourceMessageRequestEndWhistle>()
        .Subscribe(_=>{
            _AudioSource.PlayOneShot(_SE_List._EndWhistle);
        })
        .AddTo(this);

        _AudioSourceMessageBroker.Receive<AudioSourceMessageRequestExplosion>()
        .Subscribe(_=>{
            _AudioSource.PlayOneShot(_SE_List._Explosion);
        })
        .AddTo(this);

        _AudioSourceMessageBroker.Receive<AudioSourceMessageRequestExplosion2>()
        .Subscribe(_=>{
            _AudioSource.PlayOneShot(_SE_List._Explosion2);
        })
        .AddTo(this);

        _AudioSourceMessageBroker.Receive<AudioSourceMessageRequestUfoGet>()
        .Subscribe(_=>{
            _AudioSource.PlayOneShot(_SE_List._UfoGet);
        })
        .AddTo(this);

         _AudioSourceMessageBroker.Receive<AudioSourceMessageRequestOnSatellite>()
        .Subscribe(_=>{
            _AudioSource.PlayOneShot(_SE_List._OnSatellite);
        })
        .AddTo(this);

         _AudioSourceMessageBroker.Receive<AudioSourceMessageRequestSatelliteDestroy>()
        .Subscribe(_=>{
            _AudioSource.PlayOneShot(_SE_List._SatelliteDestroy);
        })
        .AddTo(this);
    }

    
}
