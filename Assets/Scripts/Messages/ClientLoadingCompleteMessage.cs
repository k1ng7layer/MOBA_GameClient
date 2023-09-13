using System;

namespace Messages
{
    [Serializable]
    public readonly struct ClientLoadingCompleteMessage
    {
        public readonly int clientId;

        public ClientLoadingCompleteMessage(int clientId)
        {
            this.clientId = clientId;
        }
    }
}