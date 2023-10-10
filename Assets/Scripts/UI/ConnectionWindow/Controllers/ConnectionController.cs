using System.Collections;
using System.Net;
using Core.Systems;
using PBUnityMultiplayer.Runtime.Core.Authentication;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Utils;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
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

        public ConnectionController(INetworkClientManager networkClientManager)
        {
            _networkClientManager = networkClientManager;
        }
        
        public void Initialize()
        {
            View.connectionButton.OnClickAsObservable().Subscribe(_ =>
            {
               _networkClientManager.StartClient();
               _networkClientManager.ConnectToServer("12");
            }).AddTo(View);
        }
    }
}