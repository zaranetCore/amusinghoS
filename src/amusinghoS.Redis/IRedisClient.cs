using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace amusinghoS.Redis
{
    public interface IRedisClient
    {
        string Get(string key);
        void Set(string key, object t, int expiresSec = 0);
        T Get<T>(string key) where T : new();
        Task<string> GetAsync(string key);
        Task SetAsync(string key, object t, int expiresSec = 0);
        Task<T> GetAsync<T>(string key) where T : new();
        Task RPushAsync(string key, object t, int expiresSec = 0);
    }
}
