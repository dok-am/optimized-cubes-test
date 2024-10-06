using CubeTest.Instances.Interfaces;
using UnityEngine;

namespace CubeTest.Factories
{
    public class CubeFactory <T> where T : Object, ICubeInstance
    {
        private T _cubePrefab;
        private Transform _container;

        public CubeFactory(T prefab, Transform container)
        {
            _cubePrefab = prefab;
            _container = container;
        }

        public T SpawnCube(Vector3 position)
        {
            return GameObject.Instantiate(_cubePrefab, position, Quaternion.identity, _container);
        }
    }
}
