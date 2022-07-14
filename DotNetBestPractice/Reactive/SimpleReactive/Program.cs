using System.Reactive.Linq;

IObservable<string> obj = Observable.Generate(0,
    _ => true,
    i => i + 1,
    i => new string('#', i),
    i => TimeSelector(i)
    );



using (obj.Subscribe(Console.WriteLine))
{
    Console.WriteLine("Preass any key");
    Console.ReadKey();
}


TimeSpan TimeSelector(int i){
    return TimeSpan.FromSeconds(i);
}