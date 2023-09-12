using System;
using Core.LoadingProcessor.Impls;
using SimpleUi.Signals;
using UI.ConnectionWindow.Window;
using Zenject;

namespace Services.LoadingProcessor.Impls
{
    public class OpenMenuWindowProcess : Process
    {
        private readonly SignalBus _signalBus;

        public OpenMenuWindowProcess(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public override void Do(Action onComplete)
        {
            //_signalBus.OpenWindow<ConnectionWindow>();
        }
    }
}