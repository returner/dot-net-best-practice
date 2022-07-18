using Observer;

var numbers = new NumbersObservable(5);
numbers.Subscribe(new ConsoleObserver<int>("AAA"));

numbers.SubscribeConsole("extension");

//////////////

