using System;

namespace Messages
{
    [Serializable]
    public struct ClientLoadingCompleteMessage
    {
        public int clientId;
    }
}