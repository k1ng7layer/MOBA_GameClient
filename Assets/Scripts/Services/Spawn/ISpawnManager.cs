using PBUnityMultiplayer.Runtime.Core.NetworkObjects;
using UnityEngine;

namespace Services.Spawn
{
    public interface ISpawnManager
    {
        NetworkObject Spawn(int prefabId, ushort networkId, int ownerId, Vector3 position, Quaternion rotation);
    }
}