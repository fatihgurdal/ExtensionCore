using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionCore
{
    public static class ObjectConverter
    {
        public static TResult ConvertObject<TRequest, TResult>(this TRequest objRequest) where TResult : new() where TRequest : new()
        {
            return ConvertObject<TRequest, TResult>(objRequest, false);
        }
        public static TResult ConvertObject<TRequest, TResult>(this TRequest objRequest, bool skipTrows) where TResult : new() where TRequest : new()
        {
            return Map<TResult>(objRequest, default, skipTrows);
        }
        public static T Map<T>(this object data, T target) where T : new()
        {
            return Map(data, target, false);
        }
        public static T Map<T>(this object data, T target, bool skipThrows) where T : new()
        {
            if (data == null) return target;

            if (target == null) target = Activator.CreateInstance<T>();

            var properties = data.GetType().GetProperties();

            var targetType = typeof(T);
            foreach (var item in properties)
            {
                var prop = targetType.GetProperty(item.Name, item.PropertyType);

                if (prop != null)
                {
                    try
                    {
                        prop.SetValue(target, item.GetValue(data, null), null);
                    }
                    catch
                    {
                        if (skipThrows == false) throw;
                    }
                }
            }
            return target;
        }
    }
}
