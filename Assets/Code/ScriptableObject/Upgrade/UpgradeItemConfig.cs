using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "UpgradeItemConfig", menuName = "Data/UpgradeItemConfig", order = 51)]
    internal sealed class UpgradeItemConfig : ScriptableObject
    {
        public ItemConfig ItemConfig;
        public UpgradeType Type;
        public float ValueUpgrade;

        public int Id => ItemConfig.Id;
    }
}