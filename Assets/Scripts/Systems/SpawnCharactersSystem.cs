using Core.Systems;
using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.NetworkObjects;
using Services.Camera;
using Services.CharacterManager;
using Services.GameState;
using Services.PlayerProvider;
using Systems.Abstract;
using Views.Character.Impl;

namespace Systems
{
    public class SpawnCharactersSystem : AGameStateSystem, IInitializeSystem
    {
        private readonly INetworkClientManager _networkClientManager;
        private readonly ICameraService _cameraService;
        private readonly ICharacterManager _characterManager;
        private readonly IPlayerProvider _playerProvider;

        public SpawnCharactersSystem(
            IGameStateProvider gameStateProvider, 
            INetworkClientManager networkClientManager,
            ICameraService cameraService,
            ICharacterManager characterManager,
            IPlayerProvider playerProvider
            ) : base(gameStateProvider)
        {
            _networkClientManager = networkClientManager;
            _cameraService = cameraService;
            _characterManager = characterManager;
            _playerProvider = playerProvider;
        }

        public override EGameState GameState => EGameState.Game;

        protected override void OnInitialize()
        {
            _networkClientManager.RegisterSpawnHandler<CharacterSpawnMessage>(OnCharacterSpawn);
        }

        protected override void OnStateChanged()
        {
            
        }

        private void OnCharacterSpawn(
            NetworkObject networkObject, 
            CharacterSpawnMessage characterSpawnMessage
        )
        {
            
            var characterView = networkObject.GetComponent<CharacterView>();
            _characterManager.InitializeCharacter(characterView);

            if (networkObject.OwnerId == _networkClientManager.LocalClient.Id)
            {
                _cameraService.SetFollowTarget(networkObject.transform);
                _playerProvider.LocalPlayer.CharacterObjectNetworkId = networkObject.Id;
            }
                
        }
    }
}