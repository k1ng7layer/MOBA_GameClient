using System;
using Core.Systems;
using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.GameState;
using UnityEngine;

namespace Systems
{
    public class SetGameStateSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly INetworkClientManager _networkClientManager;
        private readonly IGameStateProvider _gameStateProvider;

        public SetGameStateSystem(
            INetworkClientManager networkClientManager, 
            IGameStateProvider gameStateProvider
        )
        {
            _networkClientManager = networkClientManager;
            _gameStateProvider = gameStateProvider;
        }
        
        public void Initialize()
        {
            _networkClientManager.RegisterMessageHandler<ServerGameState>(OnServerStateChanged);
        }
        
        private void OnServerStateChanged(ServerGameState serverGameState)
        {
            var gameStateId = serverGameState.gameStateId;
            
            var gameState = (EGameState)gameStateId;
            Debug.Log($"received server state message = {gameState}");
            _gameStateProvider.SetState(gameState);
        }

        public void Dispose()
        {
            Debug.Log($"SetGameStateSystem disposed");
        }
    }
}