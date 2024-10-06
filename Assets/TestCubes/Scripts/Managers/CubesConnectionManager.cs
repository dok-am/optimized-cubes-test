
using CubeTest.Application;
using CubeTest.Instances;
using CubeTest.Instances.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace CubeTest.Managers
{
    public class CubesConnectionManager : ITickable
    {
        private const float MINIMAL_DISTANCE = 2.0f;


        private IPlayerCubeInstance _playerCube;
        private ICubeInstance _otherCube;

        private CubesConnectionInstance _connection;

        public CubesConnectionManager(SceneContext sceneContext)
        {
             _connection = GameObject.Instantiate(sceneContext.CubesConnectionPrefab, 
                 sceneContext.ObjectsContainer);
        }

        public void SetPlayerCube(IPlayerCubeInstance player)
        {
            _playerCube = player;
        }

        public void SetOtherCubeInstance(ICubeInstance cube)
        {
            _otherCube = cube;
        }

        public void Tick()
        {
            if (_playerCube == null || _otherCube == null)
                return;

            float sqrDistance = (_playerCube.CubeTransform.position - _otherCube.CubeTransform.position).sqrMagnitude;

            bool isClose = MINIMAL_DISTANCE * MINIMAL_DISTANCE > sqrDistance;
            _connection.Show(isClose);

            if (isClose)
            {
                _connection.UpdatePositions(_playerCube.CubeTransform, _otherCube.CubeTransform, Mathf.Sqrt(sqrDistance));
            } 
        }
    }
}