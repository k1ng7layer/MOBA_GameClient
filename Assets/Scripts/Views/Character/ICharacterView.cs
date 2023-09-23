
using UnityEngine;
using Views.Network;

namespace Views.Character
{
    public interface ICharacterView : IAiView, INetworkView
    {
        Vector3 Position { get; }
        void Initialize(int prefabId);
        void Teleport(Vector3 position);
    }
}