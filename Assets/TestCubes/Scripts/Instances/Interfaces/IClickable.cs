using System;

namespace CubeTest.Instances.Interfaces
{
    public interface IClickable 
    {
        public event Action<IClickable> OnObjectClicked;
    }
}
