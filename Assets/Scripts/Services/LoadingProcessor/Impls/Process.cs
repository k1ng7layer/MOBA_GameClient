using System;

namespace Core.LoadingProcessor.Impls
{
    public abstract class Process : IProcess
    {
        public abstract void Do(Action onComplete);
    }
}