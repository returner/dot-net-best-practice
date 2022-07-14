using System;
using System.Reactive.Linq;

var o = Observable.CombineLatest(
        Observable.StartAsync(Test1),
        Observable.StartAsync(Test2),
        Observable.StartAsync(Test3)
    ).Finally(()=> Console.WriteLine("End"));

foreach (var item in await o.FirstAsync())
{
    Console.WriteLine(item);
}


static async Task<string> Test1()
{
    await Task.CompletedTask;

    return "A";
}

static async Task<string> Test2()
{
    await Task.CompletedTask;
    return "B";
}

static async Task<string> Test3()
{
    await Task.CompletedTask;
    return "C";
}