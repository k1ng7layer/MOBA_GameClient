using PBUnityMultiplayer.Runtime.Configuration.Connection.Impl;
using PBUnityMultiplayer.Runtime.Configuration.Prefabs.Impl;
using Settings.Characters.Impl;
using Settings.TimeSettings.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScriptableNetworkConfiguration networkConfiguration;
        [SerializeField] private SoCharactersBase soCharactersBase;
        [SerializeField] private SoTimeSettings timeSettings;
        [SerializeField] private NetworkPrefabsBase networkPrefabsBase;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScriptableNetworkConfiguration>().FromInstance(networkConfiguration);
            Container.BindInterfacesAndSelfTo<SoCharactersBase>().FromInstance(soCharactersBase);
            Container.BindInterfacesAndSelfTo<SoTimeSettings>().FromInstance(timeSettings);
            Container.BindInterfacesAndSelfTo<NetworkPrefabsBase>().FromInstance(networkPrefabsBase);
        }
    }
}