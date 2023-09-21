using Messages;
using PBUnityMultiplayer.Runtime.Core.Client;
using Services.GameState;
using Services.PlayerProvider;
using SimpleUi.Signals;
using Systems.Abstract;
using UI.CharacterPick.Windows;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class StartCharacterPickSystem : AGameStateSystem
    {
        private readonly SignalBus _signalBus;
        private readonly IPlayerProvider _playerProvider;
        private readonly INetworkClientManager _networkClientManager;

        public StartCharacterPickSystem(
            IGameStateProvider gameStateProvider, 
            SignalBus signalBus,
            IPlayerProvider playerProvider,
            INetworkClientManager networkClientManager
        ) : base(gameStateProvider)
        {
            _signalBus = signalBus;
            _playerProvider = playerProvider;
            _networkClientManager = networkClientManager;
        }

        public override EGameState GameState => EGameState.CharacterPick;
        
        protected override void OnStateChanged()
        {
            _signalBus.OpenWindow<CharacterPickWindow>();
        }

        protected override void OnInitialize()
        {
            _networkClientManager.RegisterMessageHandler<TeamAssignMessage>(OnTeamAssigned);
        }

        private void OnTeamAssigned(TeamAssignMessage message)
        {
            var team = (ETeamType)message.teamIndex;

            Debug.Log($"OnTeamAssigned = {team}");
            _playerProvider.LocalPlayer = new Player(_networkClientManager.LocalClient.Id, team);
        }
    }
}