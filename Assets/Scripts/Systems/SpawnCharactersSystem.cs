using Core.Systems;
using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.NetworkObjects;
using Services.GameState;
using Systems.Abstract;

namespace Systems
{
    public class SpawnCharactersSystem : AGameStateSystem, IInitializeSystem
    {
        private readonly INetworkClientManager _networkClientManager;

        public SpawnCharactersSystem(
            IGameStateProvider gameStateProvider, 
            INetworkClientManager networkClientManager
            ) : base(gameStateProvider)
        {
            _networkClientManager = networkClientManager;
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
            
        }
    }
}