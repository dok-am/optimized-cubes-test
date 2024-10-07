using CubeTest.Application;
using CubeTest.Instances;
using CubeTest.Instances.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace CubeTest.Managers
{
    public class CubesConnectionManager : ITickable
    {
        public float DistanceBetweenBalls { get; private set; }

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

        public void SetDistanceForced(float distance)
        {
            DistanceBetweenBalls = distance;
            Vector3 delta =  _otherCube.CubeTransform.position - _playerCube.CubeTransform.position;
            delta = delta.normalized * DistanceBetweenBalls;
            Vector3 newPosition = _playerCube.CubeTransform.position + delta;
            newPosition.y = _playerCube.CubeTransform.position.y;
            _otherCube.Rigidbody.position = newPosition;
        }

        public void Tick()
        {
            if (_playerCube == null || _otherCube == null)
                return;

            DistanceBetweenBalls = 
                (_playerCube.CubeTransform.position - _otherCube.CubeTransform.position).magnitude;

            bool isClose = DistanceBetweenBalls < MINIMAL_DISTANCE;
            _connection.Show(isClose);

            if (!isClose)

                return;

           _connection.UpdatePositions(_playerCube.CubeTransform, 
               _otherCube.CubeTransform, 
               DistanceBetweenBalls);
        }
    }
}