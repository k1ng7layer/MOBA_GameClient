using Cinemachine;
using UnityEngine;

namespace Services.Camera
{
    public interface ICameraService
    {
        UnityEngine.Camera MainCamera { get; }
        void AddCamera(CinemachineVirtualCamera cinemachineVirtualCamera);
        void SetFollowTarget(Transform target);
    }
}