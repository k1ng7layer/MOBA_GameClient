using System;
using Core.Systems;
using Messages;
using PBUdpTransport.Utils;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.Camera;
using Services.Input;
using UniRx;
using UnityEngine;

namespace Systems.Input
{
    public class PlayerDestinationSystem : IInitializeSystem
    {
        private readonly ICameraService _cameraService;
        private readonly IPlayerInputService _playerInputService;
        private readonly INetworkClientManager _networkClientManager;

        public PlayerDestinationSystem(
            ICameraService cameraService,
            IPlayerInputService playerInputService,
            INetworkClientManager networkClientManager
        )
        {
            _cameraService = cameraService;
            _playerInputService = playerInputService;
            _networkClientManager = networkClientManager;
        }
        
        public void Initialize()
        {
            _playerInputService.PlayerMouseClicked.Subscribe(OnPlayerClicked);
        }

        private void OnPlayerClicked(Vector3 mousePosition)
        {
            var ray = _cameraService.MainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("GameField")))
            {
                var clickedPoint = hit.point;
                
                var destinationMessage = new PlayerDestinationMessage
                {
                    PlayerId = _networkClientManager.LocalClient.Id,
                    X = clickedPoint.x,
                    Y = clickedPoint.y,
                    Z = clickedPoint.z
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