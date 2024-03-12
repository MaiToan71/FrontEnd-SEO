using Project.Caching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Caching
{
    public class CachingExtension : ICachingExtension
    {
        private readonly ICaching _cache;

        public CachingExtension(ICaching caching)
        {
            _cache = caching;
        }

        public bool TryGetCache<T>(out T obj, string key) where T : new()
        {
            try
            {
                //if (SettingExtention.Instance.Setting.EnableCaching && _cache.Exists(key))
                if (_cache.Exists(key))
                {
                    obj = _cache.Get<T>(key);
                    return true;
                }
            }
            catch (Exception)
            {
            }

            obj = new T();

            return false;
        }

        public void SetCache(string key, object obj, int seconds)
        {
            try
            {
                //if (SettingExtention.Instance.Setting.EnableCaching && obj != null)
                if (obj != null)
                {
                    _cache.Set(key, obj, seconds);
                }
            }
            catch (Exception)
            {
            }

        }

        public void DeleteCache(string key)
        {
            try
            {
                if (_cache.Exists(key))
                {
                    _cache.Delete(key);
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
