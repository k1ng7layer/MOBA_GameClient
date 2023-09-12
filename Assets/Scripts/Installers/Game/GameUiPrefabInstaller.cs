using SimpleUi;
using UI.CharacterPick.Controller;
using UI.CharacterPick.View;
using UI.ConnectionWindow.Controllers;
using UI.ConnectionWindow.View;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameUiPrefabInstaller), fileName = nameof(GameUiPrefabInstaller))]
    public class GameUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private ConnectionView connectionView;
        [SerializeField] private CharacterPickListView characterPickListView;

        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            
            Container.BindUiView<ConnectionController, ConnectionView>(connectionView, canvasTransform);
            Container.BindUiView<CharacterPickListController, CharacterPickListView>(characterPickListView, canvasTransform);
        }
    }
}