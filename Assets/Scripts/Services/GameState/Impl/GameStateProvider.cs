using System;
using System.Collections.Generic;
using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;

namespace Services.GameState.Impl
{
    public class GameStateProvider : IGameStateProvider
    {
        private readonly Dictionary<EGameState, HashSet<IGameStateListener>> _gameStateListeners = new();

        public event Action<EGameState> GameStateChanged;
        public EGameState CurrentState { get; private set; }
        
        public void SetState(EGameState gameState)
        {
            CurrentState = gameState;
            
            GameStateChanged?.Invoke(gameState);
        }

        public void AddGameStateListener(IGameStateListener gameStateListener)
        {
            if(!_gameStateListeners.ContainsKey(gameStateListener.GameState))
                _gameStateListeners.Add(gameStateListener.GameState, new HashSet<IGameStateListener>());

            var listeners = _gameStateListeners[gameStateListener.GameState];
            
            listeners.Add(gameStateListener);
        }

        public void RemoveGameStateListener(IGameStateListener gameStateListener)
        {
            var hasListener = _gameStateListeners.TryGetValue(gameStateListener.GameState, 
                out var listeners);
            
            if(hasListener)
            {
                listeners.Remove(gameStateListener);
            }
        }
    }
}