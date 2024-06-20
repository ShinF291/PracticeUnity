using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Appdata
{
    public class AppDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AppData>().To<AppData>().AsSingle();

        }
    }
}
