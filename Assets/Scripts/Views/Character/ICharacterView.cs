
using UnityEngine;

namespace Views.Character
{
    public interface ICharacterView : IAiView
    {
        Vector3 Position { get; }
        void Initialize(int prefabId);
    }
}