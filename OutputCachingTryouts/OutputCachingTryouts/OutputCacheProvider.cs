using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutputCachingTryouts
{
    public class CustomOutputCacheProvider : System.Web.Caching.OutputCacheProvider
    {
        Dictionary<string, object>  _dictionary = new Dictionary<string, object>();

        public Dictionary<string, object> Content
        {
            get { return _dictionary; }
        }

        public override object Get(string key)
        {
            object o;

            if (_dictionary.TryGetValue(key, out o))
            {
                return o;
            }
            return null;
        }

        public override object Add(string key, object entry, DateTime utcExpiry)
        {



            object o;
            if (!_dictionary.TryGetValue(key, out o))
            {
                _dictionary.Add(key, entry);
                return entry;

            }
            return o;




        }

        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            if (utcExpiry > DateTime.UtcNow)
            {
                _dictionary[key] = entry;
            }
            

        }

        public override void Remove(string key)
        {
            _dictionary.Remove(key);
        }
    }
}