using SimpleUi;
using UI.CharacterPick.Controller;

namespace UI.CharacterPick.Windows
{
    public class CharacterPickWindow : WindowBase
    {
        public override string Name => "CharacterPickWindow";
        
        protected override void AddControllers()
        {
            AddController<CharacterPickListController>();
        }
    }
}