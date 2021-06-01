using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal sealed class CameraShakeBehaviour : MonoBehaviour
    {
        [SerializeField] private ShakeData _data;
        private Transform _cameraTransform;

        private void OnValidate()
        {
            _cameraTransform = Camera.main.transform;
        }

        public void CreateShake()
        {
            Tweener tweener = DOTween.Shake(() => _cameraTransform.position, pos => _cameraTransform.position = pos,
                _data.Duration, _data.Strength, _data.Vibrato, _data.Randomness);
        }
    }
}