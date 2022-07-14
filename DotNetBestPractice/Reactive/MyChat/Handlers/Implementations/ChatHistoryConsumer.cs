using MyChat.Models;

namespace MyChat.Handlers.Implementations
{
    public class ChatHistoryConsumer : BackgroundService
    {
        private readonly IChatEventHandler _eventHandler;

        public ChatHistoryConsumer(IChatEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _eventHandler.Subscribe(subscriberName: typeof(ChatHistoryConsumer).Name, action: async (e) =>
            {
                if (e is ChatMessageReceivedEvent)
                {
                    await PersistChatMessageToDBAsync(e);
                }
            });

            return Task.CompletedTask;
        }

        private async Task PersistChatMessageToDBAsync(ChatMessageReceivedEvent e)
        {
            await System.Console.Out.WriteLineAsync($"Chat message received and persisted:{e.Message}");
        }
    }
}
