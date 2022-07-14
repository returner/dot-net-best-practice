using MyChat.Models;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MyChat.Handlers.Implementations
{
    public class ChatEventHandler : IChatEventHandler, IDisposable
    {
        private readonly Subject<ChatMessageReceivedEvent> _subject;
        private readonly Dictionary<string, IDisposable> _subscribers;

        public ChatEventHandler()
        {
            _subject = new Subject<ChatMessageReceivedEvent>();
            _subscribers = new Dictionary<string, IDisposable>();
        }

        public void Publish(ChatMessageReceivedEvent eventMessage)
        {
            _subject.OnNext(eventMessage);
        }

        public void Subscribe(string subscriberName, Action<ChatMessageReceivedEvent> action)
        {
            if (!_subscribers.ContainsKey(subscriberName))
            {
                _subscribers.Add(subscriberName, _subject.Subscribe(action));
            }
        }

        public void Subscribe(string subscriberName, Func<ChatMessageReceivedEvent, bool> predictate, Action<ChatMessageReceivedEvent> action)
        {
            if (!_subscribers.ContainsKey(subscriberName))
            {
                _subscribers.Add(subscriberName, _subject.Where(predictate).Subscribe(action));
            }
        }

        public void Dispose()
        {
            if (_subject != null)
            {
                _subject.Dispose();
            }
            foreach (var subscriber in _subscribers)
            {
                subscriber.Value.Dispose();
            }
        }
    }
}
