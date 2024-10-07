using CubeTest.Instances.Interfaces;
using TriInspector;
using UnityEngine;

namespace CubeTest.Instances
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeInstance : MonoBehaviour, ICubeInstance, IClickable
    {

        public Transform CubeTransform => _cachedTransform;

        
        [SerializeField, ReadOnly] protected Transform _cachedTransform;



        private void OnValidate()
        {
            if (_cachedTransform == null)
                _cachedTransform = transform;
        }
    }
}
