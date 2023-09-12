using System;
using Services.SceneLoading;
using UnityEngine.SceneManagement;

namespace Core.LoadingProcessor.Impls
{
    public class SetActiveSceneProcess : Process, IProgressable
    {
        private readonly ELevelName _levelName;
        public float Progress => .5f;

        public SetActiveSceneProcess(ELevelName levelName)
        {
            _levelName = levelName;
        }

        public override void Do(Action onComplete)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_levelName.ToString()));
            onComplete();
        }
    }
}