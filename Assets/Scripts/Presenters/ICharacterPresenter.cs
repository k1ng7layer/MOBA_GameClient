using UnityEngine;
using Views.Character;

namespace Presenters
{
    public interface ICharacterPresenter
    {
        ICharacterView View { get; }
        int CharacterNetworkId { get; }
        Vector3 Position { get; }
        Vector3 Destination { get; }
        void SetDestination(Vector3 destination);
        void Teleport(Vector3 position);
    }
}