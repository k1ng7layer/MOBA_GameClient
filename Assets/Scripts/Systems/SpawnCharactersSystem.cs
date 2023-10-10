using Core.Systems;
using Factories.Character;
using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.NetworkObjects;
using Services.Camera;
using Services.CharacterManager;
using Services.CharacterPresenterRepository;
using Services.GameState;
using Services.PlayerProvider;
using Services.Spawn;
using Systems.Abstract;
using UnityEngine;
using Views.Character.Impl;

namespace Systems
{
    public class SpawnCharactersSystem : AGameStateSystem, IInitializeSystem
    {
        private readonly INetworkClientManager _networkClientManager;
        private readonly ICameraService _cameraService;
        private readonly ICharacterManager _characterManager;
        private readonly IPlayerProvider _playerProvider;
        private readonly ISpawnManager _spawnManager;
        private readonly ICharacterPresenterRepository _characterPresenterRepository;
        private readonly CharacterFactory _characterFactory;
        private readonly CharacterPresenterFactory _characterPresenterFactory;

        public SpawnCharactersSystem(
            IGameStateProvider gameStateProvider, 
            INetworkClientManager networkClientManager,
            ICameraService cameraService,
            ICharacterManager characterManager,
            IPlayerProvider playerProvider,
            ISpawnManager spawnManager,
            ICharacterPresenterRepository characterPresenterRepository,
            CharacterFactory characterFactory,
            CharacterPresenterFactory characterPresenterFactory
            ) : base(gameStateProvider)
        {
            _networkClientManager = networkClientManager;
            _cameraService = cameraService;
            _characterManager = characterManager;
            _playerProvider = playerProvider;
            _spawnManager = spawnManager;
            _characterPresenterRepository = characterPresenterRepository;
            _characterFactory = characterFactory;
            _characterPresenterFactory = characterPresenterFactory;
        }

        public override EGameState GameState => EGameState.Game;

        protected override void OnInitialize()
        {
            _networkClientManager.RegisterMessageHandler<CharacterSpawnMessage>(OnCharacterSpawn);
        }

        protected override void OnStateChanged()
        {
            
        }

        private void OnCharacterSpawn(CharacterSpawnMessage msg)
        {
            var spawnPosition = new Vector3(msg.PositionX, msg.PositionY, msg.PositionZ);
            var spawnRotation = new Quaternion(msg.RotationX, msg.RotationY, msg.RotationZ, msg.RotationW);
            var networkObject = _spawnManager.Spawn(msg.CharacterId, msg.NetworkId, msg.ClientId, spawnPosition, spawnRotation);
            var characterView = networkObject.GetComponent<CharacterView>();
            var character = _characterFactory.Create();
            var characterPresenter = _characterPresenterFactory.Create(characterView, character);
            var networkId = networkObject.Id;
            _characterPresenterRepository.Add(networkId, characterPresenter);
            
            if (networkObject.OwnerId == _networkClientManager.LocalClient.Id)
            {
                _cameraService.SetFollowTarget(networkObject.transform);
                _playerProvider.LocalPlayer.CharacterObjectNetworkId = networkObject.Id;
            }
        }
    }
}