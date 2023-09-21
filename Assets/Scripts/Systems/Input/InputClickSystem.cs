using System;
using Core.Systems;
using Messages;
using PBUdpTransport.Utils;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.Camera;
using Services.CharacterPresenterRepository;
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
        private readonly ICharacterPresenterRepository _characterPresenterRepository;

        public PlayerDestinationSystem(
            ICameraService cameraService,
            IPlayerInputService playerInputService,
            INetworkClientManager networkClientManager,
            IPlayerProvider playerProvider,
            ICharacterPresenterRepository characterPresenterRepository
        )
        {
            _cameraService = cameraService;
            _playerInputService = playerInputService;
            _networkClientManager = networkClientManager;
            _playerProvider = playerProvider;
            _characterPresenterRepository = characterPresenterRepository;
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
                var localPlayer = _playerProvider.LocalPlayer;
                var playerId = localPlayer.CharacterObjectNetworkId;
                var localPlayerPresenter = _characterPresenterRepository.TryGetPresenter(playerId, out var presenter);
                var view = presenter.View;
                Debug.Log($"");
                var destinationMessage = new PlayerDestinationMessage
                {
                    clientId = _networkClientManager.LocalClient.Id,
                    networkObjectId = _playerProvider.LocalPlayer.CharacterObjectNetworkId,
                    x = clickedPoint.x,
                    y = view.Position.y,
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