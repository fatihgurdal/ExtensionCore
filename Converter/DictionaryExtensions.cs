using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionCore
{
    public static class DictionaryExtensions
    {
        public static void AddOrUpdate<Key, Value>(this Dictionary<Key, Value> dictionary, Key key, Value value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }
    }
}
