using TriInspector;
using UnityEngine;

namespace CubeTest.Instances
{
    public class CubesConnectionInstance : MonoBehaviour
    {
        private const int OBJECTS_COUNT = 2;

        [TableList(AlwaysExpanded = true,
            Draggable = false,
            HideAddButton = true,
            HideRemoveButton = true)]
        [SerializeField] private ParticleSystem[] _particles = new ParticleSystem[OBJECTS_COUNT];
        [SerializeField, ReadOnly] private Transform[] _cachedTransform = new Transform[OBJECTS_COUNT];

        private ParticleSystem.MainModule[] _particleModules = new ParticleSystem.MainModule[OBJECTS_COUNT];

        private bool _isShowing;

        private void Awake()
        {
            for (int i = 0; i < OBJECTS_COUNT; i++)
            {
                var particleSystem = _particles[i];
                if (particleSystem != null)
                {
                    _particleModules[i] = particleSystem.main;
                }
            }
        }

        public void Show(bool show)
        {
            if (_isShowing == show)
                return;

            foreach(var particleSystem in _particles)
            {
                if (show)
                {
                    particleSystem.Play();
                }
                else
                {
                    particleSystem.Stop();
                }
            }

            _isShowing = show;
        }

        public void UpdatePositions(Transform object1, Transform object2, float distance)
        {
            _particleModules[0].startLifetime = distance / _particleModules[0].startSpeed.constant;
            _particleModules[1].startLifetime = distance / _particleModules[1].startSpeed.constant;

            SetParticleSystemPosition(_cachedTransform[0], object1.position, object2);
            SetParticleSystemPosition(_cachedTransform[1], object2.position, object1);
        }

        private void SetParticleSystemPosition(Transform particleTransform,
            Vector3 position, 
            Transform lookAtTarget)
        {
            particleTransform.position = position;
            particleTransform.LookAt(lookAtTarget);
        }

        private void OnValidate()
        {
            for (int i = 0; i < OBJECTS_COUNT; i++)
            {
                var particleSystem = _particles[i];
                if (particleSystem != null)
                {
                    _particleModules[i] = particleSystem.main;
                }
            }
        }
    }
}