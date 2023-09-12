using System;
using System.Collections;
using Services.SceneLoading;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.LoadingProcessor.Impls
{
    public class LoadingProcess : Process, IProgressable
    {
        public float Progress => _operation?.progress ?? 0;

        private readonly ELevelName _levelName;
        private readonly LoadSceneMode _mode;
        private AsyncOperation _operation;
        private Action _complete;

        public LoadingProcess(ELevelName levelName, LoadSceneMode mode)
        {
            _levelName = levelName;
            _mode = mode;
        }

        public override void Do(Action complete)
        {
            _complete = complete;
            _operation = SceneManager.LoadSceneAsync(_levelName.ToString(), _mode);
            Observable.FromCoroutine(() => VerifySceneLoad(_operation))
                .Subscribe(_ => _complete());
        }

        private IEnumerator VerifySceneLoad(AsyncOperation operation)
        {
            operation.allowSceneActivation = true;
            while (!operation.isDone)
            {
                yield return null;
            }
        }
    }
}