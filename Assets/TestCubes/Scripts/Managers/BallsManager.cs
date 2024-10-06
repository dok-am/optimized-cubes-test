using CubeTest.Application;
using CubeTest.Instances.Interfaces;
using CubeTest.Managers.Interfaces;
using UnityEngine;

namespace CubeTest.Managers
{
    public class BallsManager 
    {
        private GameObject _balls;
        private IPlayerCubeInstance _player;

        public BallsManager(SceneContext sceneContext, 
            IInputManager inputManager, 
            PlayerManager playerManager)
        {
            _balls = sceneContext.Balls;
            playerManager.OnPlayerSpawned += OnPlayerSpawned;
            inputManager.OnMouseClicked += OnMouseClicked;
        }

        private void OnPlayerSpawned(IPlayerCubeInstance player)
        {
            _player = player;
        }

        private void OnMouseClicked(IClickable clickable)
        {
            if (clickable == _player)
                ToggleBalls();
        }

        private void ToggleBalls()
        {
            _balls.SetActive(!_balls.activeSelf);
        }
    }
}