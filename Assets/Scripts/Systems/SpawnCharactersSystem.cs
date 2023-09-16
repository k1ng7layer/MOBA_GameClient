using Core.Systems;
using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.NetworkObjects;
using Services.Camera;
using Services.GameState;
using Systems.Abstract;

namespace Systems
{
    public class SpawnCharactersSystem : AGameStateSystem, IInitializeSystem
    {
        private readonly INetworkClientManager _networkClientManager;
        private readonly ICameraService _cameraService;

        public SpawnCharactersSystem(
            IGameStateProvider gameStateProvider, 
            INetworkClientManager networkClientManager,
            ICameraService cameraService
            ) : base(gameStateProvider)
        {
            _networkClientManager = networkClientManager;
            _cameraService = cameraService;
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
            _cameraService.SetFollowTarget(networkObject.transform);
        }
    }
}