namespace ChatService
{
    public interface IChatConnection
    {
        event Action<string> Received;
        event Action Closed;
        event Action<Exception> Error;

        void Disconnect();
    }
}
