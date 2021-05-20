using System;
using UnityEngine;


namespace JevLogin
{
    internal sealed class ItemScenePresenter : MonoBehaviour
    {
        internal Action PickedUp;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        internal void Present(IItem item)
        {
            _spriteRenderer.sprite = item.Info.Image;
            gameObject.name = item.Info.Name;
        }

        public void PickUp()
        {
            PickedUp?.Invoke();
        }
    }
}