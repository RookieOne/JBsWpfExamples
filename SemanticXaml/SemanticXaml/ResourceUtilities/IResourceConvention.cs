using System.Collections;
using System.Reflection;

namespace SemanticXaml.ResourceUtilities
{
    public interface IResourceConvention
    {
        bool CanBeAppliedTo(string key);
        void ApplyConvention(Assembly assembly, DictionaryEntry entry);
    }
}