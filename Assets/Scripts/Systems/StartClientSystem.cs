using Core.Systems;
using PBUnityMultiplayer.Runtime.Core.Client;

namespace Systems
{
    public class StartClientSystem : IInitializeSystem
    {
        private readonly INetworkClientManager _networkClientManager;

        public StartClientSystem(INetworkClientManager networkClientManager)
        {
            _networkClientManager = networkClientManager;
        }
        
        public void Initialize()
        {
            
        }
    }
}