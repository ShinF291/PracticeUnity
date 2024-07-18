using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Appdata;

namespace RaMen.RamenData
{
    public class RamenDataInstaller : MonoInstaller
    {
        [Inject]
        private AppData _AppData;

        [SerializeField]
        private List<RamenData> _RamenDataList;

        public override void InstallBindings()
        {
            int stageNumber = _AppData.StageNumber;
            
            if(_AppData.StageNumber >= _RamenDataList.Count)
            {
                stageNumber = 0;
            }
            Container.Bind<RamenData>().FromScriptableObject(_RamenDataList[stageNumber]).AsSingle();
            
        }
    }
}
