using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.CharacterPick.View
{
    public class CharacterPickViewElement : UiView
    {
        [SerializeField]private Image icon;
        [SerializeField] private Button selectButton;
        [SerializeField] private GameObject selectedFrame;
        
        private readonly ReactiveCommand<int> _selected = new();
        public int Id { get; private set;}

        public ReactiveCommand<int> Selected => _selected;

        public void Initialize(int id, Sprite characterIcon)
        {
            Id = id;
            icon.sprite = characterIcon;
            selectButton.OnClickAsObservable()
                .Subscribe(_ => { Selected.Execute(Id); })
                .AddTo(gameObject);
            
            SetSelected(false);
        }

        public void SetSelected(bool value)
        {
            selectedFrame.SetActive(value);
        }
    }
}