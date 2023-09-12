using System.Collections.Generic;

namespace Settings.Characters
{
    public interface ICharactersBase
    {
        IReadOnlyList<CharacterVo> GetCharacters();
        CharacterVo GetCharacter(int id);
    }
}