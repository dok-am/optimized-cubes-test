using CubeTest.Instances;
using TriInspector;
using UnityEngine;

namespace CubeTest.Application
{
    public class SceneContext : MonoBehaviour
    {
        public CubeInstance CubePrefab => _cubePrefab;
        public PlayerCubeInstance PlayerCubePrefab => _playerCubePrefab;
        public Transform ObjectsContainer => _objectsContainer;

        public Transform PlayerSpawnPoint => _playerSpawnPoint;
        public Transform OtherCubeSpawnPoint => _otherCubeSpawnPoint;


        [Title("Injected prefabs")]
        [SerializeField, Required] private CubeInstance _cubePrefab;
        [SerializeField, Required] private PlayerCubeInstance _playerCubePrefab;

        [Title("Scene objects")]
        [SerializeField, Required] private Transform _objectsContainer;
        [SerializeField, Required] private Transform _playerSpawnPoint;
        [SerializeField, Required] private Transform _otherCubeSpawnPoint;

    }
}