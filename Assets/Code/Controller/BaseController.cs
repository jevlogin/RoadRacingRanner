using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    internal abstract class BaseController : IDisposable
    {
        #region Fields

        private List<BaseController> _baseControllers;
        private List<GameObject> _gameObjects;
        private bool _isDisposed;

        #endregion


        #region IDisposable

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                if (_baseControllers != null)
                {
                    foreach (BaseController baseController in _baseControllers)
                    {
                        baseController?.Dispose();
                    }
                    _baseControllers.Clear();
                }

                if (_gameObjects != null)
                {
                    foreach (GameObject cahedGameObject in _gameObjects)
                    {
                        Object.Destroy(cahedGameObject);
                    }
                    _gameObjects.Clear();
                }
                OnDispose();
            }
        }

        #endregion


        #region Methods

        protected void AddController(BaseController baseController)
        {
            if (_baseControllers == null)
            {
                _baseControllers = new List<BaseController>();
            }
            _baseControllers.Add(baseController);
        }

        protected void AddGameObjects(GameObject gameObject)
        {
            if (_gameObjects == null)
            {
                _gameObjects = new List<GameObject>();
            }
            _gameObjects.Add(gameObject);
        }

        protected virtual void OnDispose()
        {
        }

        #endregion
    }
}