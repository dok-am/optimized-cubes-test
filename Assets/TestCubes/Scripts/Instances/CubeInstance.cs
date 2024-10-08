using CubeTest.Instances.Interfaces;
using TriInspector;
using UnityEngine;

namespace CubeTest.Instances
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeInstance : MonoBehaviour, ICubeInstance, IClickable
    {
        public Transform CubeTransform => _cachedTransform;
        public Rigidbody Rigidbody => _cachedRigidbody;

        [SerializeField, ReadOnly] protected Transform _cachedTransform;
        [SerializeField, ReadOnly] protected Rigidbody _cachedRigidbody;

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
            if (_cachedTransform == null)
                _cachedTransform = transform;
            if (_cachedRigidbody == null)
                _cachedRigidbody = GetComponent<Rigidbody>();
        }
    }
}
