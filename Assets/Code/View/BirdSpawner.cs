using System.Collections;
using UnityEngine;


namespace JevLogin
{
    internal sealed class BirdSpawner : BaseInputView
    {
        #region Fields

        [SerializeField] private DuckView _birdPrefab;
        [SerializeField] private Transform[] _spawnPoints;

        [SerializeField] private float _minDelay = 0.1f;
        [SerializeField] private float _maxDelay = 1.0f;

        private IAnalyticTools _unityAnalyticTools;
        private SubscriptionProperty<int> _countBirdDead = new SubscriptionProperty<int>();

        #endregion


        #region ClassLifeCycles

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            _unityAnalyticTools = new UnityAnalyticTools();

            StartCoroutine(SpawnCars());
        }


        private void OnDestroy()
        {
            //Debug.Log($"Count die Bird = {_countBirdDead.Value}");
            _unityAnalyticTools.SendMessage($"Count die Bird = {_countBirdDead.Value}");
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

                var bird = Instantiate(_birdPrefab, spawnPoint.position, spawnPoint.rotation);
                bird.Init(_countBirdDead);

                Destroy(bird.gameObject, 3.0f);
            }
        }

        #endregion
    }
}