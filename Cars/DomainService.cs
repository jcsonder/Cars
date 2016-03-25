using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cars.Persistence;

namespace Cars
{
    // todo: Create appropriate namespace
    public class DomainService
    {
        public DomainService()
        {
            _dataRepository = new DataRepository();
        }

        private readonly DataRepository _dataRepository;

        public async Task<string> GetDataAsync()
        {
            string data = await _dataRepository.RetrieveDataAsync().ConfigureAwait(false);
            data = ComputeData(data);
            return data;
        }

        private string ComputeData(string data)
        {
            Task.Delay(2000).Wait();
            return data.ToUpper();
        }

        public IObservable<long> LoadDataAsync()
        {
            return _dataRepository.LoadDataAsync();
        }
    }
}
