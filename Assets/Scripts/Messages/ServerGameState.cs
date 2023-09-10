using System;
using Services.GameState;

namespace Messages
{
    [Serializable]
    public struct ServerGameState
    {
        public EGameState State;
    }
}