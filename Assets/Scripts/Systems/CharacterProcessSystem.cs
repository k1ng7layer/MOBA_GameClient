using System.Collections.Generic;
using Core.Systems;
using Factories.Character;
using Presenters;
using Presenters.Impl;
using Services.CharacterManager;
using Services.CharacterPresenterRepository;
using Views.Character.Impl;

namespace Systems
{
    public class CharacterProcessSystem : IInitializeSystem, ICharacterManager
    {
        private readonly CharacterFactory _characterFactory;
        private readonly CharacterPresenterFactory _characterPresenterFactory;
        private readonly ICharacterPresenterRepository _characterPresenterRepository;
        private readonly List<ICharacterPresenter> _characterPresenters = new();

        public CharacterProcessSystem(
            CharacterFactory characterFactory,
            CharacterPresenterFactory characterPresenterFactory,
            ICharacterPresenterRepository characterPresenterRepository)
        {
            _characterFactory = characterFactory;
            _characterPresenterFactory = characterPresenterFactory;
            _characterPresenterRepository = characterPresenterRepository;
        }
        
        public void Initialize()
        {
            // _teamSpawnService.TeamSpawned.Subscribe(OnTeamSpawned);
        }

        private void OnTeamSpawned(List<CharacterView> characterViews)
        {
            foreach (var characterView in characterViews)
            {
                var character = _characterFactory.Create();
                var characterPresenter = _characterPresenterFactory.Create(characterView, character);
                var networkId = characterView.NetworkObjectId;
                _characterPresenters.Add(characterPresenter);
                _characterPresenterRepository.Add(networkId, characterPresenter);
            }
        }

        public void InitializeCharacter(CharacterView characterView)
        {
            var character = _characterFactory.Create();
            var characterPresenter = _characterPresenterFactory.Create(characterView, character);
            var networkId = characterView.NetworkObjectId;
            _characterPresenters.Add(characterPresenter);
            _characterPresenterRepository.Add(networkId, characterPresenter);
        }
    }
}