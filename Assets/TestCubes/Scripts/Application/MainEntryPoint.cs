using CubeTest.Managers;
using CubeTest.UI.Controllers;
using VContainer.Unity;

namespace CubeTest.Application
{
    public class MainEntryPoint : IInitializable, IStartable
    {
        private PlayerManager _playerManager;
        private CubeManager _cubesManager;
        private SceneContext _sceneContext;
        private CubesConnectionManager _cubesConnectionManager;

        public MainEntryPoint(PlayerManager playerManager, 
            CubeManager cubesManager, 
            SceneContext context, 
            CubesConnectionManager cubesConnectionManager,
            BallsManager ballsManager)
        {
            _playerManager = playerManager;
            _cubesManager = cubesManager;
            _sceneContext = context;
            _cubesConnectionManager = cubesConnectionManager;
        }

        public void Initialize()
        {
            _playerManager.OnPlayerSpawned += _cubesConnectionManager.SetPlayerCube;
            _playerManager.OnPlayerDespawn += _ => _cubesConnectionManager.SetPlayerCube(null);

            _cubesManager.OnCubeSpawned += _cubesConnectionManager.SetOtherCubeInstance;
            _cubesManager.OnCubeDespawn += _ => _cubesConnectionManager.SetOtherCubeInstance(null);
        }

        public void Start()
        {
            _cubesManager.SpawnCube(_sceneContext.OtherCubeSpawnPoint.position);
            _playerManager.SpawnPlayer(_sceneContext.PlayerSpawnPoint.position);
        }
    }
}
