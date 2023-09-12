namespace Services.SceneLoading
{
    public interface ISceneLoadingManager
    {
        void LoadGameLevel(ELevelName levelName);
        void LoadGameFromMenu();
        void LoadGameFromSplash();
        float GetProgress();
    }
}