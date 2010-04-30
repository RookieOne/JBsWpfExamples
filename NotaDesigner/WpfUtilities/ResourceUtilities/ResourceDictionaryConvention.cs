using System;
using System.Collections;
using System.Reflection;
using System.Windows;

namespace WpfUtilities.ResourceUtilities
{
    public class ResourceDictionaryConvention : IResourceConvention
    {
        public void ApplyConvention(Assembly assembly, DictionaryEntry entry)
        {
            string assemblyName = assembly.GetName().Name;
            string key = entry.Key as string;
            key = key.Replace(".baml", ".xaml");

            string uriString = String.Format("pack://application:,,,/{0};Component/{1}", assemblyName, key);

            try
            {
                if (!uriString.ToUpper().Contains("VIEW.XAML")
                    && !uriString.ToUpper().Contains("APP.XAML"))
                {
                    var dictionary = new ResourceDictionary
                                         {
                                             Source = new Uri(uriString)
                                         };

                    Application.Current.Resources.MergedDictionaries.Add(dictionary);
                }
            }
            catch
            {
                // do nothing. This allows for user controls to 'not' be loaded into the
                // Resource Dictionary
            }
        }

        public bool CanBeAppliedTo(string key)
        {
            return key.Contains(".baml");
        }
    }
}