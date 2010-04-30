using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfUtilities.ResourceUtilities
{
    public class ImageConvention : IResourceConvention
    {
        public ImageConvention()
        {
            _imageSuffixes = new[] {".png", ".jpg", ".gif"};
        }

        readonly IEnumerable<string> _imageSuffixes;
        string _matchedSuffix;

        public void ApplyConvention(Assembly assembly, DictionaryEntry entry)
        {
            var key = entry.Key.ToString();

            var startIndex = key.LastIndexOf('/') + 1;
            var endIndex = key.LastIndexOf(_matchedSuffix);
            var length = endIndex - startIndex;
            var imageName = entry.Key.ToString().Substring(startIndex, length);

            var chars = imageName.ToCharArray();
            chars[0] = Char.ToUpper(chars[0]);

            var newKey = new string(chars) + "Image";

            var i = new BitmapImage();
            i.BeginInit();
            i.StreamSource = entry.Value as Stream;
            i.CacheOption = BitmapCacheOption.OnLoad;
            i.CreateOptions = BitmapCreateOptions.None;
            i.EndInit();

            if (Application.Current != null)
                Application.Current.Resources.Add(newKey, i);
        }

        public bool CanBeAppliedTo(string key)
        {
            foreach (var suffix in _imageSuffixes)
            {
                if (key.Contains(suffix))
                {
                    _matchedSuffix = suffix;
                    return true;
                }
            }

            return false;
        }
    }
}