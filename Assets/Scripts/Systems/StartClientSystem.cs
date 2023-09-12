using System;
using Core.Systems;
using PBUnityMultiplayer.Runtime.Core.Client;
using SimpleUi.Signals;
using UI.ConnectionWindow.Window;
using Zenject;

namespace Systems
{
    public class StartClientSystem : IInitializeSystem, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly INetworkClientManager _networkClientManager;

        public StartClientSystem(SignalBus signalBus, 
            INetworkClientManager networkClientManager)
        {
            _signalBus = signalBus;
            _networkClientManager = networkClientManager;
        }
        
        public void Initialize()
        {
            _signalBus.OpenWindow<ConnectionWindow>();
        }

        void IDisposable.Dispose()
        {
            _networkClientManager.StopClient();
        }
    }
}