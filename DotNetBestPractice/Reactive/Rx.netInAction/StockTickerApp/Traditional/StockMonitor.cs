namespace StockTickerApp.Traditional
{
    public class StockMonitor
    {
        private Dictionary<string, StockInfo> _stockInfos = new Dictionary<string, StockInfo>();
        const decimal maxChangeRatio = 0.1m;
        private readonly StockTicker _ticker;
        public StockMonitor(StockTicker ticker)
        {
            _ticker = ticker;
            _ticker.StockTick += OnStockTick;
        }

        public void Dispose()
        {
            _ticker.StockTick -= OnStockTick;
            _stockInfos.Clear();
        }

        private void OnStockTick(object? sender, StockTick stockTick)
        {
            StockInfo stockInfo;
            var quoteSymbol = stockTick.QuoteSymbol;

            var stockInfoExist = _stockInfos.TryGetValue(quoteSymbol, out stockInfo);
            if (stockInfoExist)
            {
                var priceDiff = stockTick.Price - stockInfo.PrevPrice;
                var changeRatio = Math.Abs(priceDiff / stockInfo.PrevPrice);
                if (changeRatio > maxChangeRatio)
                {
                    // ..
                }
            } else
            {
                _stockInfos[quoteSymbol] = new StockInfo(quoteSymbol, stockTick.Price);
            }
        }

        object _stockTickLocker = new object();
        private void OnStockTickLock(object? sender, StockTick stockTick)
        {
            StockInfo stockInfo;
            var quoteSymbol = stockTick.QuoteSymbol;

            lock(_stockTickLocker)
            {
                var stockInfoExist = _stockInfos.TryGetValue(quoteSymbol, out stockInfo);
                if (stockInfoExist)
                {
                    var priceDiff = stockTick.Price - stockInfo.PrevPrice;
                    var changeRatio = Math.Abs(priceDiff / stockInfo.PrevPrice);
                    if (changeRatio > maxChangeRatio)
                    {
                        // ..
                    }
                }
                else
                {
                    _stockInfos[quoteSymbol] = new StockInfo(quoteSymbol, stockTick.Price);
                }
            }
        }
    }
}
