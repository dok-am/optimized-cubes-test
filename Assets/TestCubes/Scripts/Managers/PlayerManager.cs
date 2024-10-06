using CubeTest.Factories;
using CubeTest.Instances;
using CubeTest.Instances.Interfaces;
using CubeTest.Managers.Interfaces;
using System;
using UnityEngine;
using VContainer.Unity;

namespace CubeTest.Managers
{
    public class PlayerManager : IFixedTickable
    {
        public event Action<IPlayerCubeInstance> OnPlayerSpawned;
        public event Action<IPlayerCubeInstance> OnPlayerDespawn;

        private CubeFactory<PlayerCubeInstance> _factory;
        private IInputManager _inputManager;

        private PlayerCubeInstance _player;

        public PlayerManager(CubeFactory<PlayerCubeInstance> factory, IInputManager inputManager)
        {
            _factory = factory;
            _inputManager = inputManager;
        }

        public void SpawnPlayer(Vector3 position)
        {
            DespawnPlayer();

            _player = _factory.SpawnCube(position);
            _inputManager.OnMoveInput += _player.SetInput;

            OnPlayerSpawned?.Invoke(_player);
        }

        public void DespawnPlayer()
        {
            if (_player != null)
            {
                _inputManager.OnMoveInput -= _player.SetInput;
                OnPlayerDespawn?.Invoke(_player);
                GameObject.Destroy(_player.gameObject);
                _player = null;
            }
        }

        public void FixedTick()
        {
            if (_player == null)
                return;

            _player.CustomFixedUpdate(Time.fixedDeltaTime);
        }
    }
}