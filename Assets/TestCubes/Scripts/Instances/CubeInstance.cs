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



        private void OnValidate()
        {
            // Note: Good thing, but it breaks instantiating by AddComponent<CubeInstance>() 
            // It make sense to create a dedicated function and call it from OnValidate and Awake
            // It also may cause bugs if you copy that component on another object, it keeps the original references, and you can't change them except resetting component
            if (_cachedTransform == null)
                _cachedTransform = transform;
            if (_cachedRigidbody == null)
                _cachedRigidbody = GetComponent<Rigidbody>();
        }
    }
}
