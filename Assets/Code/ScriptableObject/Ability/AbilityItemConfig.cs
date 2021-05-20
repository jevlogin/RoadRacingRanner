using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "AbilityItemConfig", menuName = "Data/AbilityItemConfig", order = 51)]
    internal sealed class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig ItemConfig;
        public GameObject View;
        public AbilityType Type;
        public float Value;
        public int Id => ItemConfig.Id;
    }
}