using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cs.Basket.Core.Caching
{
    public interface ICacheManager
    {
        Task<T> GetAsync<T>(string key);
        Task<bool> IsExistsAsync(string key);
        Task RemoveAsync(string key);
        Task SetAsync(string key, object data, int cacheTime);
    }
}
