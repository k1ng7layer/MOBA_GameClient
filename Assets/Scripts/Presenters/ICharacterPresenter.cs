using UnityEngine;
using Views.Character;

namespace Presenters
{
    public interface ICharacterPresenter
    {
        ICharacterView View { get; }
        void SetDestination(Vector3 destination);
    }
}