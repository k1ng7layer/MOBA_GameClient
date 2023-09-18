using UnityEngine;

namespace Services.Raycast
{
    public interface IRaycastProvider
    {
        bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit raycastHit, float length, LayerMask layerMask);
    }
}