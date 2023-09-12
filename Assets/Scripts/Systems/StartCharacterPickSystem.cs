using Services.GameState;
using SimpleUi.Signals;
using Systems.Abstract;
using UI.CharacterPick.Windows;
using Zenject;

namespace Systems
{
    public class StartCharacterPickSystem : AGameStateSystem
    {
        private readonly SignalBus _signalBus;

        public StartCharacterPickSystem(
            IGameStateProvider gameStateProvider, 
            SignalBus signalBus) : base(gameStateProvider)
        {
            _signalBus = signalBus;
        }

        protected override EGameState GameState => EGameState.CharacterPick;
        
        protected override void OnGameStateChanged()
        {
            _signalBus.OpenWindow<CharacterPickWindow>();
            
        }
    }
}