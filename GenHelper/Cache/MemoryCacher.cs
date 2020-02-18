using System;
using System.Runtime.Caching;

namespace GenHelper.Cache
{
    public class MemoryCacher
    {
        public object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        public bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }
        public bool AddMinutes(string key, object value, double absMinuteExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, this.GetMinutes(absMinuteExpiration));
        }
        public bool AddSeconds(string key, object value, double absSecondsExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, this.GetSeconds(absSecondsExpiration));
        }

        private DateTimeOffset GetMinutes(double minutes)
        {
            return DateTimeOffset.Now.AddMinutes(minutes);
        }
        private DateTimeOffset GetSeconds(double seconds)
        {
            return DateTimeOffset.Now.AddMinutes(seconds);
        }
        public void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }          
        }
    }
}
