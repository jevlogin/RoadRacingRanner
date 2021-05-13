using UnityEngine;


namespace JevLogin
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class CarView : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}