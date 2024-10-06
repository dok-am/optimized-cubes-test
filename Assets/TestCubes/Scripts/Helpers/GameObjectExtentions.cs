using UnityEngine;

namespace CubeTest.Helpers
{
    public static class GameObjectExtentions 
    {
        public enum UnityLayers
        {
            Default = 0,
            Cube = 3
        }

        public static bool CheckLayer(this GameObject gameObject, UnityLayers layer)
        {
            return gameObject.layer == (int)layer;
        }
    }
}