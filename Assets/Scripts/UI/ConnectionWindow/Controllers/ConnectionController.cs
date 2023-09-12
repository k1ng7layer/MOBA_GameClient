using System.Collections;
using System.Net;
using Core.Systems;
using PBUnityMultiplayer.Runtime.Configuration.Connection;
using PBUnityMultiplayer.Runtime.Core.Authentication;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Utils;
using SimpleUi.Abstracts;
using UI.ConnectionWindow.View;
using UniRx;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace UI.ConnectionWindow.Controllers
{
    public class ConnectionController : UiController<ConnectionView>, 
        IInitializable
    {
        private readonly INetworkClientManager _networkClientManager;
        private readonly INetworkConfiguration _networkConfiguration;

        public ConnectionController(
            INetworkClientManager networkClientManager, 
            INetworkConfiguration networkConfiguration)
        {
            _networkClientManager = networkClientManager;
            _networkConfiguration = networkConfiguration;
        }
        
        public void Initialize()
        {
            View.connectionButton.OnClickAsObservable().Subscribe(_ =>
             {
                 View.StartCoroutine(ConnectRoutine());
             }).AddTo(View);
        }

        private async UniTaskVoid Next()
        {
            View.connectionButton.interactable = false;
            
            var result = await Connect();
            
            if (result.ConnectionResult != EConnectionResult.Success)
                View.connectionButton.interactable = true;
            
            Debug.Log($"connection result = {result.ConnectionResult}, reason = {result.Message}");
        }

        private IEnumerator ConnectRoutine()
        {
            Debug.Log($"ConnectRoutine");
            View.connectionButton.interactable = false;
            
            var task = Connect();

            while (!task.IsCompleted)
            {
                yield return null;
            }

            var result = task.Result;
            
            if (result.ConnectionResult != EConnectionResult.Success)
                View.connectionButton.interactable = true;
            
            Debug.Log($"connection result = {result.ConnectionResult}, reason = {result.Message}");
        }

        private async UniTask<AuthenticateResult> Connect()
        {
            var serverIpStr = _networkConfiguration.ServerIp;
            var serverPort = _networkConfiguration.ServerPort;
            var serverIp = IPAddress.Parse(serverIpStr);
            var serverEndPoint = new IPEndPoint(serverIp, serverPort);
            
            return await _networkClientManager.ConnectToServerAsClientAsync(serverEndPoint, "12");
        }
    }
}