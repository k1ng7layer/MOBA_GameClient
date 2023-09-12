using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.CharacterPick.View
{
    public class CharacterPickListView : UiView
    {
        [SerializeField] public Button lockCharacterBtn;
        [SerializeField] public CharacterPickListCollection characterPickListCollection;
        [SerializeField] public TextMeshProUGUI selectedCharacterNameText;
    }
}