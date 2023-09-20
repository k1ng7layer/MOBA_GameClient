using Core.Systems.Impls;
using Factories.Character;
using Presenters.Impl;
using Services.Camera;
using Services.CharacterPresenterRepository.Impl;
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
using Views.Character.Impl;
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
            BindFactories();
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
            Container.BindInterfacesAndSelfTo<CharacterProcessSystem>().AsSingle();
        }

        private void BindManagers()
        {
            var cameraService = new CameraService(gameFieldView.GameCamera);
            Container.Bind<ICameraService>().To<CameraService>().FromInstance(cameraService);
            
            Container.BindInterfacesAndSelfTo<UnityTimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterPresenterRepository>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindFactory<CharacterView, Models.Character, CharacterPresenter, CharacterPresenterFactory>().AsSingle();
            Container.BindFactory<Models.Character, CharacterFactory>().AsSingle();
        }
    }
}