using CubeTest.Instances;
using TriInspector;
using UnityEngine;

namespace CubeTest.Application
{
    public class SceneContext : MonoBehaviour
    {
        public CubeInstance CubePrefab => _cubePrefab;
        public PlayerCubeInstance PlayerCubePrefab => _playerCubePrefab;
        public CubesConnectionInstance CubesConnectionPrefab => _cubesConnectionPrefab;
        public Transform ObjectsContainer => _objectsContainer;

        public Transform PlayerSpawnPoint => _playerSpawnPoint;
        public Transform OtherCubeSpawnPoint => _otherCubeSpawnPoint;
        public Camera Camera => _camera;
        public GameObject Balls => _balls;
        public LayerMask ClickLayerMask => _clickLayerMask;


        [Title("Injected prefabs")]
        [SerializeField, Required] private CubeInstance _cubePrefab;
        [SerializeField, Required] private PlayerCubeInstance _playerCubePrefab;
        [SerializeField, Required] private CubesConnectionInstance _cubesConnectionPrefab;

        [Title("Scene objects")]
        [SerializeField, Required] private Transform _objectsContainer;
        [SerializeField, Required] private Transform _playerSpawnPoint;
        [SerializeField, Required] private Transform _otherCubeSpawnPoint;
        [SerializeField, Required] private Camera _camera;
        [SerializeField, Required] private GameObject _balls;

        [Title("Settings")]
        [SerializeField] private LayerMask _clickLayerMask;
    }
}