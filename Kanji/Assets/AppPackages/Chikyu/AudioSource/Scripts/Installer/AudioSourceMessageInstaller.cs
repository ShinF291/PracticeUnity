using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MamoriOfChikyu.AudioSourceMessage;

public class AudioSourceMessageInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<AudioSourceMessageBroker>().AsSingle();
        
    }
}
