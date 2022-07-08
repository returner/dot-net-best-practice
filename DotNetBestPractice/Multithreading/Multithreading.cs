public class Multithreading
{
    public void FirstMethod()
    {
        Console.WriteLine("First Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(1000);
        Console.WriteLine("First Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    }
    public void SecondMethod()
    {
        Console.WriteLine("Second Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(1000);
        Console.WriteLine("Second Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    }
    public void ThirdMethod()
    {
        Console.WriteLine("Third Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(1000);
        Console.WriteLine("Third Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
    }

    public void ExecuteMultithreading()
    {
        var t1 = new Thread(new ThreadStart(FirstMethod));
        var t2 = new Thread(new ThreadStart(SecondMethod));
        var t3 = new Thread(new ThreadStart(ThirdMethod));

        t1.Start();
        t2.Start();
        t3.Start();
    }
}

