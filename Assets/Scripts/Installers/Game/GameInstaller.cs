using Core.Systems.Impls;
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
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnityTimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartClientSystem>().AsSingle();

            BindWindows();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<ConnectionWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterPickWindow>().AsSingle();
        }
    }
}