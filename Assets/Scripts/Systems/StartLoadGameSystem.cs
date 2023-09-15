using Services.GameState;
using Services.SceneLoading;
using Systems.Abstract;

namespace Systems
{
    public class StartLoadGameSystem : AGameStateSystem
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;

        public StartLoadGameSystem(
            IGameStateProvider gameStateProvider, 
            ISceneLoadingManager sceneLoadingManager
        ) : base(gameStateProvider)
        {
            _sceneLoadingManager = sceneLoadingManager;
        }

        public override EGameState GameState => EGameState.ClientLoading;
        
        protected override void OnStateChanged()
        {
            _sceneLoadingManager.LoadGameLevel(ELevelName.Game);
        }
    }
}