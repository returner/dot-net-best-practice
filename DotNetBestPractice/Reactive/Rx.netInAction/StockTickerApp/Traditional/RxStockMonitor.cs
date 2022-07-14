using System.Reactive.Linq;

namespace StockTickerApp.Traditional
{
    public class RxStockMonitor : IDisposable
    {
        private IDisposable _subscription;

        public RxStockMonitor(StockTicker ticker)
        {
            const decimal maxChangeRation = 0.1m;
            
            var ticks = Observable.FromEventPattern<EventHandler<StockTick>, StockTick>(
                h => ticker.StockTick += h,
                h => ticker.StockTick -= h
                ).Select(tickEvent => tickEvent.EventArgs)
                .Synchronize();

            var drasticChanges = from tick in ticks
                                 group tick by tick.QuoteSymbol
                                 into company
                                 from tickPair in company.Buffer(2, 1)
                                 let changeRatio = Math.Abs((tickPair[1].Price - tickPair[0].Price) / tickPair[0].Price)
                                 where changeRatio > maxChangeRation
                                 select new
                                 {
                                     Symbol = company.Key,
                                     ChangeRatio = changeRatio,
                                     OldPrice = tickPair[0].Price,
                                     NewPrice = tickPair[1].Price
                                 };
            _subscription = drasticChanges.Subscribe(change =>
            {
                Console.Write($"Symbol:{change.Symbol} / ChangeRatio:{change.ChangeRatio} / OldPrice:{change.OldPrice} / NewPrice:{change.NewPrice}");
            }, ex => 
            { 
                //exception handling
            }, () => 
            { 
                // observable completion code
            });
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }

}
