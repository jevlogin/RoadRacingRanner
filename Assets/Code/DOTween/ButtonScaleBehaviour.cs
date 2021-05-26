using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace JevLogin
{
    [RequireComponent(typeof(Button))]
    internal sealed class ButtonScaleBehaviour : MonoBehaviour
    {
        [SerializeField] private ScaleData _pointerDownScale;
        [SerializeField] private ScaleData _pointerUpScale;

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}