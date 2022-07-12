namespace CircuitBreakerPattern
{
    public class CircuitBreakerImplement : ICircuitBreakerStateStore
    {
        public CircuitBreakerStateEnum State => throw new NotImplementedException();

        public Exception LastException => throw new NotImplementedException();

        public DateTime LastStateChangedDateUtc => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public void HalfOpen()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Trip(Exception ex)
        {
            throw new NotImplementedException();
        }
    }

}
