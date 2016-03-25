using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public class DataRepository
    {
        public Task<string> RetrieveDataAsync()
        {
            return Task.Factory.StartNew<string>(() =>
            {
                Task.Delay(5000).Wait();
                return "data";
            });
        }

        public IObservable<long> LoadDataAsync()
        {
            return Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Take(10);
        }
    }
}
