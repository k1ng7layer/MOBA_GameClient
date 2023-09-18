using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services.Input.Impl
{
    public class PlayerInputService : IPlayerInputService, 
        IInitializable,
        IDisposable
    {
        private readonly ReactiveCommand<Vector3> _playerMouseClicked = new();

        public ReactiveCommand<Vector3> PlayerMouseClicked => _playerMouseClicked;

        public void Initialize()
        {
            Observable.EveryUpdate()
                .Where(_ => UnityEngine.Input.GetMouseButtonDown(0))
                .Subscribe(_ =>
                {
                    var mousePos = UnityEngine.Input.mousePosition;
                    PlayerMouseClicked.Execute(mousePos);
                });

        }

        public void Dispose()
        {
            _playerMouseClicked.Dispose();
        }
    }
}