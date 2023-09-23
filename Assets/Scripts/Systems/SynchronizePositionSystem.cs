using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.CharacterPresenterRepository;
using Services.GameState;
using Settings.Synchronization;
using Systems.Abstract;
using UnityEngine;

namespace Systems
{
    public class SynchronizePositionSystem : AGameStateSystem
    {
        private readonly INetworkClientManager _networkClientManager;
        private readonly ICharacterPresenterRepository _characterPresenterRepository;
        private readonly ISynchronizationSettings _synchronizationSettings;

        public SynchronizePositionSystem(
            IGameStateProvider gameStateProvider, 
            INetworkClientManager networkClientManager,
            ICharacterPresenterRepository characterPresenterRepository,
            ISynchronizationSettings synchronizationSettings
        ) : base(gameStateProvider)
        {
            _networkClientManager = networkClientManager;
            _characterPresenterRepository = characterPresenterRepository;
            _synchronizationSettings = synchronizationSettings;
        }

        public override EGameState GameState => EGameState.Game;
        
        protected override void OnStateChanged()
        {
            _networkClientManager.RegisterMessageHandler<PositionSyncMessage>(OnPositionSynchronizeMessage);
        }

        private void OnPositionSynchronizeMessage(PositionSyncMessage message)
        {
            var characterId = message.networkObjId;

            var hasPresenter = _characterPresenterRepository.TryGetPresenter(characterId, out var presenter);
            
            if(hasPresenter)
                return;

            var clientPosition = presenter.Position;
            var realPosition = new Vector3(message.actualX, message.actualY, message.actualZ);
            var realDestination = new Vector3(message.destinationX, message.destinationY, message.destinationZ);

            var div = _synchronizationSettings.PositionDivergence;
            var positionDiff2 = (realPosition - clientPosition).sqrMagnitude;
            var maxDiv2 = div * div;

            if (positionDiff2 >= maxDiv2)
            {
                Debug.Log($"presenter.Teleport id {presenter.CharacterNetworkId}");
                presenter.Teleport(realPosition);
            }
            
            var clientDestination = presenter.Destination;
            var destinationDiff2 = (realDestination - clientDestination).sqrMagnitude;
            
            if (destinationDiff2 >= maxDiv2)
            {
                Debug.Log($"presenter.SetDestination id {presenter.CharacterNetworkId}");
                presenter.SetDestination(realDestination);
            }
        }
    }
}