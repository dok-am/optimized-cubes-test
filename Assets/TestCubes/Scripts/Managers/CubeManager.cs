using CubeTest.Application;
using CubeTest.Factories;
using CubeTest.Instances;
using CubeTest.Instances.Interfaces;
using System;
using UnityEngine;

namespace CubeTest.Managers
{
    public class CubeManager 
    {
        public event Action<ICubeInstance> OnCubeSpawned;
        public event Action<ICubeInstance> OnCubeDespawn;

        private CubeFactory<CubeInstance> _factory;

        private CubeInstance _cube;

        public CubeManager(CubeFactory<CubeInstance> factory, SceneContext sceneContext)
        {
            _factory = factory;
        }

        public void SpawnCube(Vector3 position)
        {
            DespawnCube();

            _cube = _factory.SpawnCube(position);
            OnCubeSpawned?.Invoke(_cube);
        }

        public void DespawnCube()
        {
            if (_cube == null)
                return;
            
            OnCubeDespawn?.Invoke(_cube);
            GameObject.Destroy(_cube.gameObject);
            _cube = null;
        }
    }
}
