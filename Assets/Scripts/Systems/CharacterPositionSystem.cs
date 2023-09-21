using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.CharacterPresenterRepository;
using Services.GameState;
using Systems.Abstract;
using UnityEngine;

namespace Systems
{
    public class CharacterPositionSystem : AGameStateSystem
    {
        private readonly INetworkClientManager _networkClientManager;
        private readonly ICharacterPresenterRepository _characterPresenterRepository;

        public CharacterPositionSystem(
            IGameStateProvider gameStateProvider, 
            INetworkClientManager networkClientManager,
            ICharacterPresenterRepository characterPresenterRepository
        ) : base(gameStateProvider)
        {
            _networkClientManager = networkClientManager;
            _characterPresenterRepository = characterPresenterRepository;
        }

        public override EGameState GameState => EGameState.Game;
        
        protected override void OnStateChanged()
        {
            _networkClientManager.RegisterMessageHandler<PlayerDestinationMessage>(OnPositionReceived);
        }

        private void OnPositionReceived(PlayerDestinationMessage destinationMessage)
        {
            var objectId = destinationMessage.networkObjectId;
            
            var destination = new Vector3(destinationMessage.x, destinationMessage.y, destinationMessage.z);

            var hasPresenter = _characterPresenterRepository.TryGetPresenter(objectId, out var presenter);
            
            if(!hasPresenter)
                return;
            
            presenter.SetDestination(destination);
        }
    }
}