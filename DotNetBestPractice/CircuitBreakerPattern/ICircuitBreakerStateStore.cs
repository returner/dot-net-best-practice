﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakerPattern
{
    public interface ICircuitBreakerStateStore
    {
        CircuitBreakerStateEnum State { get; }
        Exception LastException { get; }
        DateTime LastStateChangedDateUtc { get; }
        void Trip(Exception ex);
        void Reset();
        void HalfOpen();
        bool IsClosed { get; }
    }
}
