using PBUnityMultiplayer.Runtime.Configuration.Connection.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScriptableNetworkConfiguration networkConfiguration;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScriptableNetworkConfiguration>().FromInstance(networkConfiguration);
        }
    }
}