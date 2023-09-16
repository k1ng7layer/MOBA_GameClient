using System;
using Cinemachine;
using Services.Camera;
using UnityEngine;
using Zenject;

namespace Views
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private Transform cameraFollowTransform;
        [SerializeField] private Camera gameCamera;
        [SerializeField] private CinemachineVirtualCamera gameVirtualCamera;

        private ICameraService _cameraService;
        
        [Inject]
        private void Construct(ICameraService cameraService)
        {
            _cameraService = cameraService;
            _cameraService.AddCamera(gameVirtualCamera);
            _cameraService.SetFollowTarget(cameraFollowTransform);
        }
    }
}