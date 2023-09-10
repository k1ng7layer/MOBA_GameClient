using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.Client.Impl;
using PBUnityMultiplayer.Runtime.Core.Server;
using PBUnityMultiplayer.Runtime.Core.Server.Impl;
using Systems;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private NetworkClientManager clientManager;
        
        public override void InstallBindings()
        {
            Container.Bind<INetworkClientManager>().To<NetworkClientManager>().FromNewComponentOnNewPrefab(clientManager)
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<SetGameStateSystem>().AsSingle();
        }
    }
}