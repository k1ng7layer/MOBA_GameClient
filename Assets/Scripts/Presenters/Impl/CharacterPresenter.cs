using UnityEngine;
using Views.Character;

namespace Presenters.Impl
{
    public class CharacterPresenter : ICharacterPresenter
    {
        private readonly ICharacterView _characterView;
        private readonly Models.Character _character;

        public CharacterPresenter(
            ICharacterView characterView, 
            Models.Character character
        )
        {
            _characterView = characterView;
            _character = character;
        }

        public ICharacterView View => _characterView;
        public int CharacterNetworkId => _characterView.NetworkObjectId;
        public Vector3 Position => _character.Position;
        public Vector3 Destination => _character.Destination;

        public void SetDestination(Vector3 destination)
        {
            _characterView.SetDestination(destination);
        }

        public void Teleport(Vector3 position)
        {
            _characterView.Teleport(position);
        }
    }
}