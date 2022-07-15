var numbers = new List<int> { 1, 2, 3, 4 };
var eventNumbers = from number in numbers where number % 2 == 0 select number;

Console.WriteLine("eventNumbers");
foreach (var number in eventNumbers)
{
    Console.WriteLine(number);
}

Console.WriteLine("eventNumbers after");
numbers.Add(6);

foreach (var number in eventNumbers)
{
    Console.WriteLine(number);
}