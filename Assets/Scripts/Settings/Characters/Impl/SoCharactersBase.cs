using System;
using System.Collections.Generic;
using PBUnityMultiplayer.Runtime.Utils.Attributes;
using UnityEngine;

namespace Settings.Characters.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SoCharactersBase), fileName = nameof(SoCharactersBase))]
    public class SoCharactersBase : ScriptableObject, 
        ICharactersBase
    {
        [KeyValue(nameof(CharacterVo.prefabId))]
        [SerializeField] private List<CharacterVo> characterVos;
        
        public IReadOnlyList<CharacterVo> GetCharacters()
        {
            return characterVos;
        }

        public CharacterVo GetCharacter(int id)
        {
            for (var i = 0; i < characterVos.Count; i++)
            {
                var characterVo = characterVos[i];
                if (characterVo.prefabId == id)
                    return characterVo;
            }

            throw new Exception($"[{nameof(SoCharactersBase)}] Can't find CharacterVo with id: {id}");
        }
    }
}