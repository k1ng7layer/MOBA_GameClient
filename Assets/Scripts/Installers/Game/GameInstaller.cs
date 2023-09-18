using Core.Systems.Impls;
using Services.Camera;
using Services.GameField;
using Services.GameField.Impl;
using Services.GameTimer.Impl;
using Services.Input.Impl;
using Services.TimeProvider.Impl;
using Systems;
using Systems.Input;
using UI.CharacterPick.Windows;
using UI.ConnectionWindow.Window;
using UnityEngine;
using Views;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameFieldView gameFieldView;
        
        public override void InstallBindings()
        {
            var gameFieldProvider = new GameFieldProvider(gameFieldView);
            Container.Bind<IGameFieldProvider>().To<GameFieldProvider>().FromInstance(gameFieldProvider);

            BindManagers();
            BindSystems();
            BindWindows();
        }

        private void BindWindows()
        {
     
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartGameSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnCharactersSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerDestinationSystem>().AsSingle();
        }

        private void BindManagers()
        {
            var cameraService = new CameraService(gameFieldView.GameCamera);
            Container.Bind<ICameraService>().To<CameraService>().FromInstance(cameraService);
            
            Container.BindInterfacesAndSelfTo<UnityTimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInputService>().AsSingle();
        }
    }
}