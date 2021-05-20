using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "Data/UpgradeItemConfigDataSource", order = 51)]
    internal sealed class UpgradeItemConfigDataSource : ScriptableObject
    {
        public UpgradeItemConfig[] ItemConfigs;
    }
}