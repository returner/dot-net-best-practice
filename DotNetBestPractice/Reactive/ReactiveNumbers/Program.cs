using System.Reactive.Linq;

IObservable<long> numbers = Observable.Interval(TimeSpan.FromSeconds(1));

numbers.Subscribe(num =>
{
    Console.WriteLine(num);
});

Console.ReadKey();

