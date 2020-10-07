using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExtensionCore
{
    public static class ListConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static List<T> ConvertTo<T>(this DataTable datatable) where T : new()
        {
            List<T> temp = new List<T>();
            try
            {
                Dictionary<string, string> columnsNames = new Dictionary<string, string>();
                var properties = typeof(T).GetProperties().Select(x => x.Name).ToList();
                var columns = datatable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
                foreach (string propertyName in properties)
                    if (columns.Any(x => x == propertyName))
                        columnsNames.Add(propertyName, columns.First(x => x == propertyName));

                temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => GetObject<T>(row, columnsNames));
                return temp;
            }
            catch
            {
                return temp;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datatable"></param>
        /// <param name="matchs">Key List object property, Value DataTable Column</param>
        /// <returns></returns>
        public static List<T> ConvertTo<T>(this DataTable datatable, Dictionary<string, string> matchs) where T : new()
        {
            List<T> temp = new List<T>();
            try
            {
                temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => GetObject<T>(row, matchs));
                return temp;
            }
            catch
            {
                return temp;
            }

        }
        public static T GetObject<T>(this DataRow row, Dictionary<string, string> matchs) where T : new()
        {
            var obj = new T();
            try
            {
                var properties = typeof(T).GetProperties().Where(x => matchs.ContainsKey(x.Name));
                foreach (PropertyInfo objProperty in properties)
                {
                    var columnname = matchs.Values.ToList().Find(name => name.Equals(objProperty.Name, StringComparison.OrdinalIgnoreCase));
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        var value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
    }
}
