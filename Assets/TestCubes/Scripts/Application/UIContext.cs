using CubeTest.UI.Views;
using TriInspector;
using UnityEngine;

namespace CubeTest.Application
{
    public class UIContext : MonoBehaviour
    {
        public DistanceView DistanceView => _distanceView;
        public ImagesWindowView ImagesWindowView => _imagesWindowView;

        [SerializeField, Required] private DistanceView _distanceView;
        [SerializeField, Required] private ImagesWindowView _imagesWindowView;
    }
}