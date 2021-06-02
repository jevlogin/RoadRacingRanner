using System.Collections.Generic;
using System.Linq;

namespace JevLogin
{
    internal class ContentDataSourceLoader
    {
        internal static List<UpgradeItemConfig> LoadUpgradeItemConfigs(ResourcePath resourcePath)
        {
            var config = ResourceLoader.LoadObject<UpgradeItemConfigDataSource>(resourcePath);
            return config == null ? new List<UpgradeItemConfig>() : config.ItemConfigs.ToList();
        }

    }
}