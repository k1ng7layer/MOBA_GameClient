using System;
using Core.Systems;
using Messages;
using PBUdpTransport.Utils;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.GameState;
using Systems.Abstract;
using UnityEngine;

namespace Systems
{
    public class StartGameSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly INetworkClientManager _networkClientManager;

        public StartGameSystem(INetworkClientManager networkClientManager
        )
        {
            _networkClientManager = networkClientManager;
        }
        
        public void Initialize()
        {
            var clientId = _networkClientManager.LocalClient.Id;
            var message = new ClientLoadingCompleteMessage(clientId);
            
            Debug.Log($"send ready message for client id {clientId}");
            _networkClientManager.SendMessage(message, ESendMode.Reliable);
        }

        void IDisposable.Dispose()
        {
            _networkClientManager.StopClient();
        }
    }
}