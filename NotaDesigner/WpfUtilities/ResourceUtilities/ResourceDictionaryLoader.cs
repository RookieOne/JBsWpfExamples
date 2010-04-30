using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;

namespace WpfUtilities.ResourceUtilities
{
    /// <summary>
    ///   Loads all Page Xaml files in the given assembly into the Merged Dictionary 
    ///   collection for the application
    /// </summary>
    public class ResourceDictionaryLoader
    {
        public ResourceDictionaryLoader()
        {
            _conventions = new List<IResourceConvention>
                               {
                                   new ResourceDictionaryConvention(),
                                   new ImageConvention()
                               };
        }

        readonly List<IResourceConvention> _conventions;

        /// <summary>
        ///   Loads the resource dictionaries from the assembly.
        /// </summary>
        public ResourceDictionaryLoader LoadResourcesFrom(Assembly assembly)
        {
            string assemblyName = assembly.GetName().Name;
            Stream stream = assembly.GetManifestResourceStream(assemblyName + ".g.resources");

            if (stream == null)
                return this;

            using (var reader = new ResourceReader(stream))
            {
                foreach (DictionaryEntry entry in reader)
                {
                    var key = (string) entry.Key;

                    foreach (var c in _conventions)
                    {
                        if (c.CanBeAppliedTo(key))
                            c.ApplyConvention(assembly, entry);
                    }
                }
            }

            return this;
        }
    }
}