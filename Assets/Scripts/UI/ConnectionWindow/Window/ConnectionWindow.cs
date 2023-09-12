using SimpleUi;
using UI.ConnectionWindow.Controllers;

namespace UI.ConnectionWindow.Window
{
    public class ConnectionWindow : WindowBase
    {
        public override string Name => "ConnectionWindow";
        
        protected override void AddControllers()
        {
            AddController<ConnectionController>();
        }
    }
}