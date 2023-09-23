using PBUnityMultiplayer.Runtime.Core.NetworkObjects;
using UnityEngine;
using UnityEngine.AI;
using Views.Network;

namespace Views.Character.Impl
{
    public class CharacterView : Network.NetworkView,
        ICharacterView
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        
        public int PrefabId { get; private set; }
        
        public void SetDestination(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
        }

        public Vector3 Position => transform.position;

        public void Initialize(int prefabId)
        {
            PrefabId = prefabId;
        }

        public void Teleport(Vector3 position)
        {
            navMeshAgent.Warp(position);
        }
    }
}