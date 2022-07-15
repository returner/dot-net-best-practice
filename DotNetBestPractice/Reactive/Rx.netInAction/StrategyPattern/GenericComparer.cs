namespace StrategyPattern
{
    public class GenericComparer<T> : IComparer<T>
    {
        private Func<T, T, int> CompareFunc { get; set; }

        public GenericComparer(Func<T, T, int> compareFunc)
        {
            CompareFunc = compareFunc;
        }
        public int Compare(T? x, T? y)
        {
            return CompareFunc(x, y);
        }
    }
}
