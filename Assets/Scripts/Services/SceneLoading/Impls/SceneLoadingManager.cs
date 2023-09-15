using Core.LoadingProcessor.Impls;
using Game.Services.LoadingProcessor.Impls;
using Services.LoadingProcessor.Impls;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.SceneLoading.Impls
{
    public class SceneLoadingManager : ISceneLoadingManager
    {
        private readonly SignalBus _signalBus;
        private Core.LoadingProcessor.Impls.LoadingProcessor _processor;
        private ELevelName _currentLevel;

        public SceneLoadingManager(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void LoadGameLevel(ELevelName levelName)
        {
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(levelName, LoadSceneMode.Single))
                .AddProcess(new SetActiveSceneProcess(levelName));
                //.AddProcess(new UnloadProcess(_currentLevel));
                
            // if (!string.IsNullOrWhiteSpace(_currentLevel.ToString()))
            // {
            //     var lastScene = SceneManager.GetSceneByName(_currentLevel.ToString());
            //     if(lastScene.IsValid() && lastScene.isLoaded)
            //         _processor.AddProcess(new UnloadProcess(_currentLevel));
            // }
            
            _processor.AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();
        }

        public void LoadGameFromMenu()
        {
            // _processor = new LoadingProcessor();
            // _processor
            //     .AddProcess(new OpenLoadingWindowProcess(_signalBus))
            //     .AddProcess(new LoadingProcess(ELevelName.GAME, LoadSceneMode.Additive))
            //     .AddProcess(new LoadingProcess(ELevelName.CITY, LoadSceneMode.Additive))
            //     .AddProcess(new SetActiveSceneProcess(ELevelName.CITY))
            //     .AddProcess(new UnloadProcess(ELevelName.MainMenu))
            //     .AddProcess(new RunContextProcess("SceneContext"))
            //     .AddProcess(new WaitUpdateProcess(4))
            //     .AddProcess(new ProjectWindowBack(_signalBus))
            //     .DoProcess();
        }

        public void LoadGameFromSplash()
        {
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.Menu, LoadSceneMode.Additive))
                .AddProcess(new UnloadProcess(ELevelName.Splash))
                .AddProcess(new RunContextProcess("MenuContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();
            _currentLevel = ELevelName.Menu;
        }

        public float GetProgress()
        {
            return _processor.Progress;
        }
    }
}