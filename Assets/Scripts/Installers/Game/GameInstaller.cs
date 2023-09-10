using Services.GameTimer.Impl;
using Services.TimeProvider.Impl;
using Systems;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UnityTimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerProvider>().AsSingle();
        }
    }
}