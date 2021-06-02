using DG.Tweening;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "ScaleData", menuName = "DOTween/ScaleData", order = 51)]
    internal sealed class ScaleData : ScriptableObject
    {
        public Ease Ease;
        public Vector2 Scale;
        [Range(0.0f, 5.0f)] public float Duration;
    }
}