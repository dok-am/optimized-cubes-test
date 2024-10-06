using CubeTest.Factories;
using CubeTest.Instances;
using CubeTest.Instances.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace CubeTest.Managers
{
    public class CubesManager 
    {
        private CubeFactory<CubeInstance> _factory;

        private List<ICubeInstance> _allCubes = new();

        public CubesManager(CubeFactory<CubeInstance> factory)
        {
            _factory = factory;
        }

        public void SpawnCube(Vector3 position)
        {
            _factory.SpawnCube(position);
        }

        public void RegisterCube(ICubeInstance cube)
        {
            _allCubes.Add(cube);
        }

        public void UnregisterCube(ICubeInstance cube)
        {
            _allCubes.Remove(cube);
        }
    }
}
