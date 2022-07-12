namespace AdapterPattern
{
    public class WildTurkey : ITurkey
    {
        public void Fly()
        {
            Console.WriteLine("Short Fly");
        }

        public void Gobble()
        {
            Console.WriteLine("Gobble");
        }
    }

}
