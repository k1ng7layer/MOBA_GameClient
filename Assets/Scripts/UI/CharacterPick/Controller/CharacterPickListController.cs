using Messages;
using PBUdpTransport.Utils;
using PBUnityMultiplayer.Runtime.Core.Client;
using Settings.Characters;
using SimpleUi.Abstracts;
using UI.CharacterPick.View;
using UniRx;
using Zenject;

namespace UI.CharacterPick.Controller
{
    public class CharacterPickListController : UiController<CharacterPickListView>, 
        IInitializable
    {
        private readonly ICharactersBase _charactersBase;
        private readonly INetworkClientManager _networkClientManager;
        private int _selectedCharacterId;

        public CharacterPickListController(
            ICharactersBase charactersBase, 
            INetworkClientManager networkClientManager
        )
        {
            _charactersBase = charactersBase;
            _networkClientManager = networkClientManager;
        }
        
        public void Initialize()
        {
            View.lockCharacterBtn.OnClickAsObservable()
                .Subscribe(_ => SelectCharacter())
                .AddTo(View);
        }
        
        public override void OnShow()
        {
            FillView();
        }

        public override void OnHide()
        {
            View.characterPickListCollection.Clear();
        }

        private void SelectCharacter()
        {
            View.lockCharacterBtn.interactable = false;
            
            SendChoice();
        }

        private void SendChoice()
        {
            var clientId = _networkClientManager.LocalClient.Id;

            var message = new CharacterSelectMessage(clientId, _selectedCharacterId);
            _networkClientManager.SendMessage(message, ESendMode.Reliable);
        }

        private void FillView()
        {
            var allCharacters = _charactersBase.GetCharacters();

            foreach (var characterVo in allCharacters)
            {
                var characterPickViewElement = View.characterPickListCollection.Create();
                
                characterPickViewElement.Initialize(characterVo.prefabId, characterVo.characterIcon);
                
                characterPickViewElement.Selected
                    .Subscribe(OnElementSelected)
                    .AddTo(characterPickViewElement.gameObject);
            }
        }
        
        private void OnElementSelected(int id)
        {
            var selected = _charactersBase.GetCharacter(id);
            View.selectedCharacterNameText.text = selected.characterName;

            foreach (var element in View.characterPickListCollection)
            {
                if(element.Id != id)
                    element.SetSelected(false);
            }
        }
    }
}