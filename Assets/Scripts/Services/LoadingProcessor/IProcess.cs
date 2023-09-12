using System;

namespace Core.LoadingProcessor
{
    public interface IProcess
    {
        void Do(Action complete);
    }
}