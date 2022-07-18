using ChatService;
using System.Reactive.Linq;

var chatClient = new ChatClient();
var connection = chatClient.Connection("guest", "password");
IObservable<string> observableConnection = new ObservableConnection(connection);

//var subscription = observableConnection.SubscribeConsole("receiver");
var subscription = chatClient.Connection("guest", "password").ToObservable().SubscribeConsole();

IObservable<string> lines = Observable.Generate(File.OpenText("test.txt"), s => !s.EndOfStream, s => s, s => s.ReadLine());

Observable.Return("Hello World").SubscribeConsole("return");

Observable.Never<string>().SubscribeConsole("NEVER");