using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "ShakeData", menuName = "DOTween/ShakeData", order = 51)]
    internal sealed class ShakeData : ScriptableObject
    {
        public float Duration;
        public float Strength;
        public int Vibrato;

        [Range(0.0f, 90.0f)] public float Randomness;
    }
}