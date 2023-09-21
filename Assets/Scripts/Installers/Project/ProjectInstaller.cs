using Core.LoadingProcessor.Impls;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.Client.Impl;
using PBUnityMultiplayer.Runtime.Core.Server;
using PBUnityMultiplayer.Runtime.Core.Server.Impl;
using Services.GameState.Impl;
using Services.PlayerProvider.Impl;
using Services.SceneLoading;
using Services.SceneLoading.Impls;
using Systems;
using UnityEngine;
using Utils.ZenjectUtils;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private NetworkClientManager clientManager;
        
        public override void InstallBindings()
        {
            var client = Container.InstantiatePrefabForComponent<NetworkClientManager>(clientManager);
            Container.BindFromSubstitute<INetworkClientManager>(client)
                .AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<GameStateProvider>().AsSingle();
            
            Container.Bind<ISceneLoadingManager>().To<SceneLoadingManager>().AsSingle();
            Container.BindInterfacesTo<LoadingProcessor>().AsSingle();
            Container.BindInterfacesAndSelfTo<SetGameStateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartLoadGameSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle();
            
            SignalBusInstaller.Install(Container);
        }
    }
}