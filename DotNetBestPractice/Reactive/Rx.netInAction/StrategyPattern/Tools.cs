using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public static class Tools
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            //implementation
        }
    }
    public static class ListExtension
    {
        public static IList<T> AddItem<T>(this IList<T> list, T item)
        {
            list.Add(item);
            return list;
        }
    }

    static class Uses
    {
        public static void Test()
        {
            var numbers = Enumerable.Range(1, 10);
            numbers.ForEach(x => Console.Write(x));
        }

        public static void StringBuild()
        {
            var sb = new StringBuilder();
            var result = sb.AppendLine("1").AppendLine("2").AppendLine("3").ToString();
        }

        public static void LsitExt()
        {
            var list = new List<string>();
            list.AddItem("D").AddItem("X");
        }

    }

    public class TestMethodUses
    {
        [TestMethod]
        public void FluentTest()
        {
            var actual = "ABDEFGFDF";
            
            Assert.IsTrue(actual.StartsWith("A"));
        }
    }

}
