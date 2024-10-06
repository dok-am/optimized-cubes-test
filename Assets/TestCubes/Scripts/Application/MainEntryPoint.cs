using CubeTest.Managers;
using VContainer.Unity;

namespace CubeTest.Application
{
    public class MainEntryPoint : IInitializable, IStartable
    {
        private PlayerManager _playerManager;
        private CubesManager _cubesManager;
        private SceneContext _sceneContext;

        public MainEntryPoint(PlayerManager playerManager, CubesManager cubesManager, SceneContext context)
        {
            _playerManager = playerManager;
            _cubesManager = cubesManager;
            _sceneContext = context;
        }

        public void Initialize()
        {
            _playerManager.OnPlayerSpawned += _cubesManager.RegisterCube;
            _playerManager.OnPlayerDespawn += _cubesManager.UnregisterCube;
        }

        public void Start()
        {
            _cubesManager.SpawnCube(_sceneContext.OtherCubeSpawnPoint.position);
            _playerManager.SpawnPlayer(_sceneContext.PlayerSpawnPoint.position);
        }
    }
}
