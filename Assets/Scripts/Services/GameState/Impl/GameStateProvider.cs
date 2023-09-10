using System;
using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;

namespace Services.GameState.Impl
{
    public class GameStateProvider : IGameStateProvider
    {
        public event Action<EGameState> GameStateChanged;
        public EGameState CurrentState { get; private set; }
        
        public void SetState(EGameState gameState)
        {
            CurrentState = gameState;
            
            GameStateChanged?.Invoke(gameState);
        }
    }
}