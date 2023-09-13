using System.Net;
using Cysharp.Threading.Tasks;
using PBUdpTransport.Models;
using PBUdpTransport.Utils;
using PBUnityMultiplayer.Runtime.Transport;
using UnityEngine;

namespace Tests.Utils
{
    public class ClientNetworkTransportMock : TransportBase
    {
        private TransportMessage _transportMessage;
        protected override void StartTransport(IPEndPoint localEndPoint)
        {
            
        }

        protected override void Send(byte[] data, IPEndPoint remoteEndpoint, ESendMode sendMode)
        {
            throw new System.NotImplementedException();
        }

        protected override UniTask SendAsync(byte[] data, IPEndPoint remoteEndpoint, ESendMode sendMode)
        {
            return UniTask.CompletedTask;
        }

        protected override async UniTask<TransportMessage> ReceiveAsync()
        {
            await UniTask.Delay(1000);
            return await UniTask.FromResult(_transportMessage);
        }

        protected override void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void AddIncomeMessageToReturn(TransportMessage transportMessage)
        {
            _transportMessage = transportMessage;
        }
    }
}
