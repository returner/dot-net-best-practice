// adapter

using AdapterPattern;

var duck = new MallardDuck();

var turkey = new WildTurkey();
var turkeyAdapter = new TurkeyAdapter(turkey);

Console.WriteLine("The turkey says...");
turkey.Gobble();
turkey.Fly();

Console.WriteLine("Thr Duck says...");
duck.Quack();
duck.Fly();

Console.WriteLine("The TurkeyAdapter says...");
turkeyAdapter.Quack();
turkeyAdapter.Fly();
