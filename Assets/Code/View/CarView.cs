using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class CarView : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        public WheelJoint2D WheelJoint2DBack;
        public WheelJoint2D WheelJoint2DForward;
        public SubscriptionProperty<bool> IsRotateWheels = new SubscriptionProperty<bool>();

        private JointMotor2D _motorStop;
        private JointMotor2D _motorActivated;

        [SerializeField] private float _speedMotor;
        [SerializeField] private List<ParticleSystem> _partikles = new List<ParticleSystem>();
        [SerializeField] private AudioClip _audioStartEngine;
        [SerializeField] private AudioClip _audioWorkingOnIdle;
        [SerializeField] private AudioClip _audioSoundInMotion;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _diffAudio = 0.01f;


        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();

            _motorStop = WheelJoint2DBack.motor;

            _motorActivated = _motorStop;
            _motorActivated.motorSpeed = _speedMotor;

            IsRotateWheels.SubscriptionOnChange(SwitchValueRotate);
            if (_audioSource.isActiveAndEnabled)
            {
                Invoke(nameof(PlayCarEngine), _audioStartEngine.length - _diffAudio); 
            }
        }

        private void PlayCarEngine()
        {
            _audioSource.clip = _audioWorkingOnIdle;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        private void OnDestroy()
        {
            IsRotateWheels.UnSubscriptionOnChange(SwitchValueRotate);
        }

        private void SwitchValueRotate(bool value)
        {
            if (IsRotateWheels.Value)
            {
                RunMotorWheel();
                foreach (var particle in _partikles)
                {
                    particle.Play();
                }
                SwitchAudioClip(_audioSoundInMotion);
            }
            else
            {
                StopMotorWheel();
                foreach (var particle in _partikles)
                {
                    particle.Stop();
                }
                SwitchAudioClip(_audioWorkingOnIdle);
            }
        }

        private void SwitchAudioClip(AudioClip audioSoundInMotion)
        {
            if (_audioSource.isActiveAndEnabled)
            {
                if (_audioSource.isPlaying)
                {
                    _audioSource.Pause();
                    _audioSource.clip = audioSoundInMotion;
                    _audioSource.Play();
                } 
            }
        }

        private void StopMotorWheel()
        {
            WheelJoint2DBack.motor = _motorStop;
            WheelJoint2DForward.motor = _motorStop;
        }

        private void RunMotorWheel()
        {
            WheelJoint2DBack.motor = _motorActivated;
            WheelJoint2DForward.motor = _motorActivated;
        }
    }
}