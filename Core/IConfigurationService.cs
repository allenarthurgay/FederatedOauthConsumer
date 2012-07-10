using System.Collections.Generic;

namespace Core
{
    public interface IConfigurationService
    {
        string AppSetting(string key);

        Dictionary<string, object> GetSettingsWithPrefix(string prefixKey);
    }
}
