using CubeTest.Instances.Interfaces;
using TriInspector;
using UnityEngine;

namespace CubeTest.Instances
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerCubeInstance : CubeInstance, IPlayerCubeInstance
    {
        [SerializeField] private float _moveForce;
        [SerializeField, ReadOnly] private Rigidbody _rigidbody;

        private Vector2 _input;

        public void SetInput(Vector2 moveInput)
        {
            _input = moveInput;
        }

        public void CustomFixedUpdate(float dt)
        {
            Vector3 force = _moveForce * dt * new Vector3(_input.x, 0.0f, _input.y);
            _rigidbody.AddForce(force);
        }

        private void Awake()
        {
            Validate();
        }

        private void OnValidate()
        {
            Validate();
        }

        private void Validate()
        {
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody>();

            if (_cachedTransform == null)
                _cachedTransform = transform;
        }
    }
}
