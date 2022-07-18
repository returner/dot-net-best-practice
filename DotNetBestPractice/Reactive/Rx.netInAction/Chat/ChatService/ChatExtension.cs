namespace ChatService
{
    public static class ChatExtension
    {
        public static IObservable<string> ToObservable(this IChatConnection connection)
        {
            return new ObservableConnection(connection);
        }
    }
}
