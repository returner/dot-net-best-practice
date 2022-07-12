using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern
{
    /// <summary>
    /// https://docs.microsoft.com/ko-KR/azure/architecture/patterns/retry
    /// </summary>
    public class Operation
    {
        private int retryCount = 3;
        private readonly TimeSpan delay = TimeSpan.FromSeconds(5);

        public async Task OperationWithBasicRetryAsync()
        {
            int currentRetry = 0;

            for (;;)
            {
                try
                {
                    // call external service.
                    await TransientOperationAsync();
                }
                catch(Exception ex)
                {
                    Trace.TraceError("Operation Exception");

                    currentRetry++;
                    if (currentRetry > this.retryCount || !IsTransient(ex))
                    {
                        throw;
                    }
                }

                await Task.Delay(delay);
            }
        }

        private bool IsTransient(Exception ex)
        {
            // Determine if the exception is transient.
            // In some cases this is as simple as checking the exception type, in other
            // cases it might be necessary to inspect other properties of the exception.
            if (ex is OperationTransientException)
            {
                return true;
            }

            var webException = ex as WebException;
            if (webException != null)
            {
                return new[]
                {
                    WebExceptionStatus.ConnectionClosed,
                    WebExceptionStatus.Timeout,
                    WebExceptionStatus.RequestCanceled
                }.Contains(webException.Status);
            }

            return false;
        }

        private async Task TransientOperationAsync()
        {
            await Task.CompletedTask;
        }
    }

    public class OperationTransientException : Exception
    {
        //
    }
}
