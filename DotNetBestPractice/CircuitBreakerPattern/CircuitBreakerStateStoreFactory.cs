namespace CircuitBreakerPattern
{
    public class CircuitBreakerStateStoreFactory
    {
        public static ICircuitBreakerStateStore GetCircuitBreakerStateStore()
        {
            return new CircuitBreakerImplement();
        }
    }

}
