using CubeTest.Managers.Interfaces;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace CubeTest.Managers
{
    public class InputManager : IInputManager, ITickable
    {
        public event Action<Vector2> OnMoveInput;

        private InputAction _moveAction;

        public InputManager()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
        }

        public void Tick()
        {
            Vector2 moveInput = _moveAction.IsPressed() ? _moveAction.ReadValue<Vector2>() : Vector2.zero;
            OnMoveInput?.Invoke(moveInput);
        }
    }
}