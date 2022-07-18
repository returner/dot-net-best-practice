using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class ConsoleObserver<T> : IObserver<T>
    {
        private readonly string _name;

        public ConsoleObserver(string name = "")
        {
            _name = name;
        }

        public void OnNext(T value)
        {
            Console.WriteLine($"{_name} - OnNext({value})");
        }

        public void OnError(Exception ex)
        {
            Console.WriteLine($"{_name} - OnError");
            Console.WriteLine($"\t {ex}");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"{_name} - OnCompleted");
        }
    }
}
