using Core.Systems;
using SimpleUi.Signals;
using UI.ConnectionWindow.Window;
using Zenject;

namespace Systems
{
    public class StartClientSystem : IInitializeSystem
    {
        private readonly SignalBus _signalBus;

        public StartClientSystem(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.OpenWindow<ConnectionWindow>();
        }
    }
}