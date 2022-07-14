using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTickerApp.DelegateSample
{
    internal class StringComparators
    {
        public static bool CompareLength(string first, string second)
        {
            return first.Length == second.Length;
        }

        public bool CompareContent(string first, string second)
        {
            return first == second;
        }
    }

    class Imple
    {
        public delegate bool ComparisonTest(string first, string second);

        public void DelegateTest()
        {
            string s1 = "Hello";
            string s2 = "World";

            var comparators = new StringComparators();
            var test = new ComparisonTest(comparators.CompareContent);
            Console.WriteLine($"CompareContent returned : {test(s1, s2)}");

            test = new ComparisonTest(StringComparators.CompareLength);
            Console.WriteLine($"CompareLength returned : {test(s1, s2)}");

            ComparisonTest test2 = comparators.CompareContent;

            string[] a1 = new[] {"", "" };
            string[] a2 = new[] {"", "" };
            string[] cities = new[] { "London", "Madrid", "TelAviv" }; 
            string[] friends = new[] { "Minnie", "Goofey", "MickeyM" };
            var isSimilar = AreSimilar(a1, a2, test2);
            var isSimilar2 = AreSimilar(friends, cities, StringComparators.CompareLength);
        }

        public void AnonymousMethodTest()
        {
            ComparisonTest lengthComparer = delegate (string first, string second)
            {
                return first.Length == second.Length;
            };

            Console.WriteLine("anonymous method returned: {0}", lengthComparer("Hello", "World"));

            string[] cities = new[] { "London", "Madrid", "TelAviv" };
            string[] friends = new[] { "Minnie", "Goofey", "MickeyM" };
            AreSimilar(friends, cities, delegate (string s1, string s2) { return s1 == s2; });
        }

        public void ClosureTest()
        {
            
            string[] cities = new[] { "London", "Madrid", "TelAviv" };
            string[] friends = new[] { "Minnie", "Goofey", "MickeyM" };

            ComparisonTest comparer; 
            {
                int moduloBase = 2;
                comparer = delegate (string s1, string s2)
                {
                    Console.WriteLine($"Modulo value : {moduloBase}");
                    return (s1.Length % moduloBase) == (s2.Length % moduloBase);
                };
                moduloBase = 3;
            }

            var similarByMod = AreSimilar(friends, cities, comparer);
            Console.WriteLine($"Similar by modulp : {similarByMod}");
        }
        
        public void LambdaTest()
        {
            ComparisonTest x = (s1, s2) => s1 == s2;
            ComparisonTest y = delegate (string s1, string s2) { return s1 == s2; };
            ComparisonTest z = (string s1, string s2) => s1 == s2;

            
        }

        bool AreSimilar(string[] leftItems, string[] rightItems, ComparisonTest tester)
        {
            if (leftItems.Length != rightItems.Length)
            {
                return false;
            }

            for (int i = 0; i < leftItems.Length; i++)
            {
                if (tester(leftItems[i], rightItems[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
