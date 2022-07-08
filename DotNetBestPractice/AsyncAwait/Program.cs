// See https://aka.ms/new-console-template for more information

var firstAsync = FirstAsync();
var secondAsync = SecondAsync();
var thirdAsync = ThirdAsync();

await Task.WhenAll(firstAsync, secondAsync, thirdAsync);


async Task FirstAsync()
{
    Console.WriteLine("First Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    await Task.Delay(1000);
    Console.WriteLine("First Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
}
async Task SecondAsync()
{
    Console.WriteLine("Second Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    await Task.Delay(1000);
    Console.WriteLine("Second Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
}
async Task ThirdAsync()
{
    Console.WriteLine("Third Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    await Task.Delay(1000);
    Console.WriteLine("Third Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
}