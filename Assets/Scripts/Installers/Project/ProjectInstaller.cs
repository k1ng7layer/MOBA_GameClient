using Core.LoadingProcessor.Impls;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.Client.Impl;
using PBUnityMultiplayer.Runtime.Core.Server;
using PBUnityMultiplayer.Runtime.Core.Server.Impl;
using Services.SceneLoading;
using Services.SceneLoading.Impls;
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
            var client = Container.InstantiatePrefabForComponent<NetworkClientManager>(clientManager);
            Container.Bind<INetworkClientManager>().To<NetworkClientManager>()
                .FromInstance(client)
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<SetGameStateSystem>().AsSingle();
            
            Container.Bind<ISceneLoadingManager>().To<SceneLoadingManager>().AsSingle();
            Container.BindInterfacesTo<LoadingProcessor>().AsSingle();
            
            SignalBusInstaller.Install(Container);
        }
    }
}