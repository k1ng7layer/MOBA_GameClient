using Views.Character.Impl;

namespace Services.CharacterManager
{
    public interface ICharacterManager
    {
        void InitializeCharacter(CharacterView characterView);
    }
}