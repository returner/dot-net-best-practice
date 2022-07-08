using System.Text;

namespace Using
{
    using System;
    using System.Text;

    public class Inner
    {
        public string Test()
        {
            var sb = new StringBuilder(20);
            sb.Append(Guid.NewGuid().ToString());
            return sb.ToString();
        }
    }

    public class Inner2
    {
        public string Test()
        {
            var sb = new StringBuilder(20);
            sb.Append(Guid.NewGuid().ToString());
            return sb.ToString();
        }
    }
}

public class Outer
{
    public string Test()
    {
        var sb = new StringBuilder(20);
        sb.Append(Guid.NewGuid().ToString());
        return sb.ToString();
    }
}