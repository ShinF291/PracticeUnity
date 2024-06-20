using UnityEngine;
using Zenject;

namespace RaMen.GuzaiCreate
{
     [CreateAssetMenu(fileName = "GuzaiScriptableInstaller", menuName = "Installers/GuzaiScriptableInstaller")]
    public class GuzaiScriptableInstaller : ScriptableObjectInstaller<GuzaiScriptableInstaller>
    {
        [SerializeField]
        private UseGuzaiList _UseGuzaiList;

        public override void InstallBindings()
        {
            Container.BindInstance(_UseGuzaiList).AsCached();
        }
    }
}