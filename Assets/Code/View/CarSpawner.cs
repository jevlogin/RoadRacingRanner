using System.Collections;
using UnityEngine;


namespace JevLogin
{
    internal sealed class CarSpawner : BaseInputView
    {
        #region Fields

        [SerializeField] private GameObject _carPrefab;
        [SerializeField] private Transform[] _spawnPoints;

        [SerializeField] private float _minDelay = 0.1f;
        [SerializeField] private float _maxDelay = 1.0f;

        #endregion


        #region ClassLifeCycles

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            StartCoroutine(SpawnCars());
        }

        #endregion


        #region Methods

        private IEnumerator SpawnCars()
        {
            while (enabled)
            {
                float delay = Random.Range(_minDelay, _maxDelay);
                yield return new WaitForSeconds(delay);

                int spawnIndex = Random.Range(0, _spawnPoints.Length);
                Transform spawnPoint = _spawnPoints[spawnIndex];

                var car = Instantiate(_carPrefab, spawnPoint.position, spawnPoint.rotation);
                
                Destroy(car, 5.0f);
            }
        }

        #endregion
    }
}