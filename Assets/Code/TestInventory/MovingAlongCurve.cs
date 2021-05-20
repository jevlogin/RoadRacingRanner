using System;
using UnityEngine;


namespace JevLogin
{
    internal class MovingAlongCurve : MonoBehaviour
    {
        private float _startTime;
        private float _duration;
        private Vector3 _from;
        private Vector3 _to;
        private Vector3 _through;

        private bool _started = false;
        private bool _removeWhenFinished;

        public MovingAlongCurve StartMoving(Vector3 from, Vector3 to, Vector3 through, float duration)
        {
            _duration = duration;
            _from = from;
            _to = to;
            _through = through;

            _started = true;
            _startTime = Time.time;

            return this;
        }

        private void Update()
        {
            if (_started)
            {
                var progress = (Time.time - _startTime) / _duration;
                transform.position = GetBezierPoint(_from, _through, _to, progress);

                if (progress >= 1 && _removeWhenFinished)
                {
                    Destroy(this);
                }
            }
        }

        private Vector3 GetBezierPoint(Vector3 a, Vector3 b, Vector3 c, float progressTime)
        {
            float negativeT = 1.0f - progressTime;
            float aCoef = negativeT * negativeT;
            float bCoef = 2 * progressTime * negativeT;
            float cCoef = progressTime * progressTime;

            return new Vector3(a.x * aCoef + b.x * bCoef + c.x * cCoef,
                                a.y * aCoef + b.y * bCoef + c.y * cCoef,
                                a.z * aCoef + b.z * bCoef + c.z * cCoef);
        }

        public void RemoveWhenFinished()
        {
            _removeWhenFinished = true;
        }
    }
}