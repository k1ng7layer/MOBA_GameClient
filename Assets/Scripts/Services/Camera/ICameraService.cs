using Cinemachine;
using UnityEngine;

namespace Services.Camera
{
    public interface ICameraService
    {
        void AddCamera(CinemachineVirtualCamera cinemachineVirtualCamera);
        void SetFollowTarget(Transform target);
    }
}