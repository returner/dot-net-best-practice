using StrategyPattern;

var wordsString = new List<string> { "ab", "a", "aabb", "abd" };
wordsString.Sort(new LengthComparer());

Console.WriteLine("LengthComparer::");
Console.WriteLine(string.Join(",", wordsString));


Console.WriteLine("GenericComparer::");
var words = new List<string> { "ab", "a", "aabb", "abd" };
var genericComparer = new GenericComparer<string> ((x, y) => (x.Length == y.Length) ? 0 : (x.Length > y.Length) ? 1 : -1 );
words.Sort(genericComparer);
Console.WriteLine(string.Join(",", words));