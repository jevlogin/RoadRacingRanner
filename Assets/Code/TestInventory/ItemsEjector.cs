using UnityEngine;

namespace JevLogin
{
    internal sealed class ItemsEjector : MonoBehaviour
    {
        [SerializeField] private ItemsObjectPool _pool;
        [SerializeField] private float _range;
        [SerializeField] private PolygonCollider2D _ground;

        private void Awake()
        {
            if (_ground == null)
            {
                _ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<PolygonCollider2D>(); 
            }
        }

        public void EjectFromPool(IItem item, Vector3 position, Vector3 direction)
        {
            var presenter = _pool.Get(item);
            presenter.transform.position = position;

            var target = position + (direction.normalized * _range);
            target = _ground.bounds.ClosestPoint(target);

            presenter.gameObject
                .AddComponent<MovingAlongCurve>()
                .StartMoving(position, target, Vector3.Lerp(position, target, 0.5f) + new Vector3(0.0f, 2.0f, 0.0f), 1)
                .RemoveWhenFinished();
        }
    }
}