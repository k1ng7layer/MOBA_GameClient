using UniRx;
using UnityEngine;

namespace Services.Input
{
    public interface IPlayerInputService
    {
        ReactiveCommand<Vector3> PlayerMouseClicked { get; }
    }
}