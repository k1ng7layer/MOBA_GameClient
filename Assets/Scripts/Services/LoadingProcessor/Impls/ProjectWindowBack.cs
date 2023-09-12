using System;
using SimpleUi.Interfaces;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Core.LoadingProcessor.Impls
{
    public class ProjectWindowBack : Process
    {
        private readonly SignalBus _signalBus;

        public ProjectWindowBack(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public override void Do(Action onComplete)
        {
            _signalBus.BackWindow(EWindowLayer.Project);
            Observable.NextFrame().Subscribe(_ => onComplete());
        }
    }
}