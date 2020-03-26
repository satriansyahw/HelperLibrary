using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GenHelper.Data
{
    public class DataManipulation
    {
        public DataManipulation()
        {

        }
        private static DataManipulation instance;
        public static DataManipulation GetInstance
        {
            get
            {
                if (instance == null) new DataManipulation();
                return instance;
            }
        }
        public T CopyDictionaryTo<T>(Dictionary<string,object> source) where T:class
        {
            var result = Activator.CreateInstance<T>();

            foreach (string myKey in source.Keys)
            {
                if (myKey.Trim() != "getInstance")
                {
                    PropertyInfo property = result.GetType().GetRuntimeProperty(myKey);
                    if (property != null)
                    {
                        if (property.CanWrite)
                        {
                            var value = source.GetValueOrDefault<string, object>(myKey);
                            property.SetValue(result, value, null);
                        }
                    }
                }
            }
            return result;
        }
        public List<T> CopyDictionaryTo<T>(List<Dictionary<string, object>> listSource) where T : class
        {
            var result = new List<T>();

            foreach (Dictionary<string, object> source in listSource)
            {
                var resultClass = Activator.CreateInstance<T>();
                foreach (string myKey in source.Keys)
                {
                    if (myKey.Trim() != "getInstance")
                    {
                        PropertyInfo property = result.GetType().GetRuntimeProperty(myKey);
                        if (property != null)
                        {
                            if (property.CanWrite)
                            {
                                var value = source.GetValueOrDefault<string, object>(myKey);
                                property.SetValue(resultClass, value, null);
                            }
                        }
                    }
                }
                result.Add(resultClass);
            }
           
            return result;
        }
        public void CopyPropertiesTo<T, TU>(T source, TU dest)
        {
            foreach (var property in source.GetType().GetRuntimeProperties())
            {
                if (!string.IsNullOrEmpty(property.Name))
                {
                    if (property.Name.Trim() != "getInstance")
                    {
                        PropertyInfo propertyS = dest.GetType().GetRuntimeProperty(property.Name);
                        if (propertyS != null)
                        {
                            if (propertyS.CanWrite)
                            {
                                var value = property.GetValue(source, null);
                                propertyS.SetValue(dest, property.GetValue(source, null), null);
                            }
                        }
                    }
                }
            }
        }
        public List<TU> CopyPropertiesTo<T, TU>(List<T> sumber)
        {
            List<TU> listDest = new List<TU>();
            foreach (var source in sumber)
            {
                TU dest = Activator.CreateInstance<TU>();
                foreach (var property in source.GetType().GetRuntimeProperties())
                {
                    if (!string.IsNullOrEmpty(property.Name))
                    {
                        if (property.Name.Trim() != "getInstance")
                        {
                            PropertyInfo propertyS = dest.GetType().GetRuntimeProperty(property.Name);
                            if (propertyS != null)
                            {
                                if (propertyS.CanWrite)
                                {
                                    var value = property.GetValue(source, null);
                                    propertyS.SetValue(dest, property.GetValue(source, null), null);
                                }
                            }
                        }
                    }
                }
                listDest.Add(dest);
            }


            return listDest;
        }
    }
}
