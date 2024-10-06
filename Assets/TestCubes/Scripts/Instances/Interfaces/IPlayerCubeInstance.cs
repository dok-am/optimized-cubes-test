using UnityEngine;

namespace CubeTest.Instances.Interfaces
{
    public interface IPlayerCubeInstance : ICubeInstance
    {
        public void SetInput(Vector2 moveInput);
        public void CustomFixedUpdate(float dt);
    }
}
