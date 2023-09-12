using System;
using Core.LoadingProcessor.Impls;
using UniRx;
using Zenject;

namespace Services.LoadingProcessor.Impls
{
    public class OpenLoadingWindowProcess : Process
    {
        private readonly SignalBus _signalBus;

        public OpenLoadingWindowProcess(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public override void Do(Action complete)
        {
            //_signalBus.OpenWindow<FirstStartLoadingWindow>(EWindowLayer.Project);
            Observable.NextFrame().Subscribe(_ => complete());
        }
    }
}