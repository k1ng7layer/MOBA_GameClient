using System;
using Core.Systems;
using Messages;
using PBUdpTransport.Utils;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.Camera;
using Services.Input;
using Services.PlayerProvider;
using UniRx;
using UnityEngine;

namespace Systems.Input
{
    public class PlayerDestinationSystem : IInitializeSystem
    {
        private readonly ICameraService _cameraService;
        private readonly IPlayerInputService _playerInputService;
        private readonly INetworkClientManager _networkClientManager;
        private readonly IPlayerProvider _playerProvider;

        public PlayerDestinationSystem(
            ICameraService cameraService,
            IPlayerInputService playerInputService,
            INetworkClientManager networkClientManager,
            IPlayerProvider playerProvider
        )
        {
            _cameraService = cameraService;
            _playerInputService = playerInputService;
            _networkClientManager = networkClientManager;
            _playerProvider = playerProvider;
        }
        
        public void Initialize()
        {
            _playerInputService.PlayerMouseClicked.Subscribe(OnPlayerClicked);
        }

        private void OnPlayerClicked(Vector3 mousePosition)
        {
            Debug.Log($"OnPlayerClicked, mouse = {mousePosition}");
            var ray = _cameraService.MainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("GameField")))
            {
                var clickedPoint = hit.point;
                
                var destinationMessage = new PlayerDestinationMessage
                {
                    clientId = _networkClientManager.LocalClient.Id,
                    networkObjectId = _playerProvider.LocalPlayer.CharacterObjectNetworkId,
                    x = clickedPoint.x,
                    y = clickedPoint.y,
                    z = clickedPoint.z
                };
                
                _networkClientManager.SendMessage(destinationMessage, ESendMode.Reliable);
                
                
            }
            else
            {
                Debug.Log($"{hit.transform.gameObject}");
            }
        }
    }
}