﻿using CubeTest.Instances.Interfaces;
using System;
using UnityEngine;

namespace CubeTest.Managers.Interfaces
{
    public interface IInputManager
    {
        public event Action<Vector2> OnMoveInput;
        public event Action<IClickable> OnMouseClicked;
    }
}