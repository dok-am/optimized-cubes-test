using CubeTest.UI.Views;
using UnityEngine;

namespace CubeTest.Application
{
    public class UIContext : MonoBehaviour
    {
        public DistanceView DistanceView => _distanceView;

        [SerializeField] private DistanceView _distanceView;
    }
}