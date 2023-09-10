using System;

namespace Messages
{
    [Serializable]
    public readonly struct CharacterPickTimerMessage
    {
        public readonly float Value;

        public CharacterPickTimerMessage(float value)
        {
            Value = value;
        }
    }
}