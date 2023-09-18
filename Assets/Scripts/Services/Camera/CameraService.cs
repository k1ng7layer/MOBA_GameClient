using Cinemachine;
using UnityEngine;

namespace Services.Camera
{
    public class CameraService : ICameraService
    {
        private CinemachineVirtualCamera _virtualCamera;

        public CameraService(UnityEngine.Camera mainCamera)
        {
            MainCamera = mainCamera;
        }
        
        public UnityEngine.Camera MainCamera { get; }

        public void AddCamera(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _virtualCamera = cinemachineVirtualCamera;
        }

        public void SetFollowTarget(Transform target)
        {
            _virtualCamera.Follow = target;
        }
    }
}