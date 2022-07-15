static IEnumerable<string> GetGreetings()
{
    yield return "Hello";
    yield return "Hi";
}

foreach (var item in GetGreetings())
{
    Console.WriteLine(item);
}

Console.WriteLine();

static IEnumerable<int> GenerateFibonacci()
{
    int a = 0;
    int b = 1;
    yield return a;
    yield return b;
    for (int i = 0; i < 10; i++)
    {
        b = a + b;
        a = b - a;
        yield return b;
    }
}

foreach (var item in GenerateFibonacci())
{
    Console.WriteLine(item);

}