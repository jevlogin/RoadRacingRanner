using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    internal sealed class ItemsObjectPool : MonoBehaviour
    {
        [SerializeField] private ItemScenePresenter _itemPresenterTemplate;

        private List<ItemScenePresenter> _avaible = new List<ItemScenePresenter>();
        private List<ItemScenePresenter> _inUse = new List<ItemScenePresenter>();

        public ItemScenePresenter Get(IItem item)
        {
            ItemScenePresenter presenter = null;

            if (_avaible.Count == 0)
            {
                presenter = Instantiate(_itemPresenterTemplate);
                presenter.Present(item);
                presenter.PickedUp += () => Release(presenter);
            }
            else
            {
                presenter = _avaible[0];
                _avaible.Remove(presenter);
            }

            _inUse.Add(presenter);
            return presenter;
        }

        private void Release(ItemScenePresenter presenter)
        {
            if (_inUse.Remove(presenter) == false)
            {
                return;
            }
            presenter.gameObject.SetActive(false);
            _avaible.Add(presenter);
        }
    }
}