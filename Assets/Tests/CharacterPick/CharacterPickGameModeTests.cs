using System.Collections;
using PBUnityMultiplayer.Runtime.Core.Client;
using PBUnityMultiplayer.Runtime.Core.Client.Impl;
using Tests.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Utils.ZenjectUtils;

namespace Tests.CharacterPick
{
    public class CharacterPickGameModeTests : NetworkTestBase
    {
        protected override void SubstituteResources()
        {
            var testNetworkClient = Resources.Load<NetworkClientManager>("NetworkClientManager");
            
            ResourceSubstitute.AddSubstitute<INetworkClientManager>(testNetworkClient);
        }
        
        [UnityTest]
        public IEnumerator CharacterPickTest()
        {
            SceneManager.LoadScene("Splash");
            yield return new WaitForSeconds(100f);
        }
    }
}
