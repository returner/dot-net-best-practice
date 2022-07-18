using System.Reactive.Linq;

namespace ChatService
{
    public class ChatClient
    {
        
        public IChatConnection Connection(string user, string password)
        {
            return new MockChatConnection();
        }
    }

    public class MockChatConnection : IChatConnection
    {
        public event Action<string> Received;
        public event Action Closed;
        public event Action<Exception> Error;

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
