namespace CircuitBreakerPattern
{
    public class CircuitBreaker
    {
        private readonly ICircuitBreakerStateStore stateStore = CircuitBreakerStateStoreFactory.GetCircuitBreakerStateStore();
        private readonly object halfOpenSyncObject = new object();
        public bool IsClosed {  get { return stateStore.IsClosed; } }
        public bool IsOpen {  get { return !IsClosed; } }
        public void ExecuteAction(Action action)
        {
            if (IsOpen)
            {
                // The circuit breaker is open.
                //....
            }

            try
            {
                action();
            }
            catch(Exception ex)
            {
                // if an exception still occurs here, simply
                // retrip the breaker immediately.
                this.TrackExceotion(ex);
                throw;
            }
        }

        private void TrackExceotion(Exception ex)
        {
            this.stateStore.Trip(ex);
        }
    }

}
