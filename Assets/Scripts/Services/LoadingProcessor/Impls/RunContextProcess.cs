﻿using System;
using Core.LoadingProcessor.Impls;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Services.LoadingProcessor.Impls
{
    public class RunContextProcess : Process
    {
        private readonly string _contextName;

        public RunContextProcess(string contextName)
        {
            _contextName = contextName;
        }

        public override void Do(Action complete)
        {
            var contexts = Object.FindObjectsOfType<SceneContext>();
            foreach (var context in contexts)
            {
                if (context.gameObject.name != _contextName)
                    continue;
                context.Run();
                complete();
                return;
            }

            throw new System.Exception($"[{nameof(RunContextProcess)}] Cannot find context with name: " + _contextName);
        }
    }
}