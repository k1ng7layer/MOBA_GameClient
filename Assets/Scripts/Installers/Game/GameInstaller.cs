using Core.Systems.Impls;
using Services.Camera;
using Services.GameTimer.Impl;
using Services.TimeProvider.Impl;
using Systems;
using UI.CharacterPick.Windows;
using UI.ConnectionWindow.Window;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
        }

        private void BindManagers()
        {
           
            Container.BindInterfacesAndSelfTo<UnityTimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraService>().AsSingle();
        }
    }
}