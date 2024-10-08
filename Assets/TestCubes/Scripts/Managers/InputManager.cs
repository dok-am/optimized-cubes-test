using CubeTest.Application;
using CubeTest.Instances.Interfaces;
using CubeTest.Managers.Interfaces;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace CubeTest.Managers
{
    public class InputManager : IInputManager, ITickable
    {
        public event Action<Vector2> OnMoveInput;
        public event Action<IClickable> OnMouseClicked;

        private InputAction _moveAction;
        private InputAction _clickAction;

        private Camera _camera;
        private LayerMask _clickLayerMask;

        private RaycastHit[] _results = new RaycastHit[1];
        private bool _isAboveUI;

        public InputManager(SceneContext sceneContext)
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _clickAction = InputSystem.actions.FindAction("Click");
            _clickAction.performed += MouseClicked;

            _camera = sceneContext.Camera;
            _clickLayerMask = sceneContext.ClickLayerMask;
        }

        public void Tick()
        {
            Vector2 moveInput = _moveAction.IsPressed() ? _moveAction.ReadValue<Vector2>() : Vector2.zero;
            OnMoveInput?.Invoke(moveInput);

            _isAboveUI = EventSystem.current.IsPointerOverGameObject();
        }

        private void MouseClicked(InputAction.CallbackContext context)
        {
            if (_isAboveUI)
                return;

            Ray cameraRay = _camera.ScreenPointToRay(Mouse.current.position.value);
            if (Physics.RaycastNonAlloc(cameraRay, _results, 100.0f, _clickLayerMask) == 0)
                return;

            GameObject ridigbodyObject = _results[0].rigidbody ? _results[0].rigidbody.gameObject : null; ;

            if (ridigbodyObject == null)
                return;

            IClickable clickable = ridigbodyObject.GetComponent<IClickable>();

            if (clickable == null)
                return;

            OnMouseClicked?.Invoke(clickable);
        }
    }
}