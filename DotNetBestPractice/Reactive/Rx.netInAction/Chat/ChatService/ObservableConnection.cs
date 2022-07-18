using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ChatService
{
    public class ObservableConnection : ObservableBase<string>
    {
        private readonly IChatConnection _chatConnection;

        public ObservableConnection(IChatConnection chatConnection)
        {
            _chatConnection = chatConnection;
        }

        protected override IDisposable SubscribeCore(IObserver<string> observer)
        {
            void received(string message)
            {
                observer.OnNext(message);
            }

            void closed()
            {
                observer.OnCompleted();
            }

            void error(Exception ex)
            {
                observer.OnError(ex);
            }
             
            _chatConnection.Received += received;
            _chatConnection.Closed += closed;
            _chatConnection.Error += error;

            return Disposable.Create(() => 
            { 
                _chatConnection.Received -= received;
                _chatConnection.Closed -= closed;
                _chatConnection.Error -= error;
                _chatConnection.Disconnect();
            });
        }

        public static IObservable<string> ObserveMessagesDeferred(string user, string password)
        {
            return Observable.Defer(() =>
            {
                var connection = Connect(user, password);
                return connection.ToObservable();
            });
        }

        public static IChatConnection Connect(string user, string password)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            return new MockChatConnection();
        }
    }
}
