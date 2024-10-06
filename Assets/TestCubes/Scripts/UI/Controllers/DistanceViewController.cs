using CubeTest.Application;
using CubeTest.Managers;
using CubeTest.UI.Views;
using VContainer.Unity;

namespace CubeTest.UI.Controllers
{
    public class DistanceViewController : ITickable
    {
        private DistanceView _distanceView;
        private CubesConnectionManager _connectionManager;

        public DistanceViewController(UIContext uiContext, CubesConnectionManager connectionManager)
        {
            _distanceView = uiContext.DistanceView;
            _connectionManager = connectionManager;
        }

        public void Tick()
        {
            _distanceView.SetText(_connectionManager.DistanceBetweenBalls.ToString("0.00"));
        }
    }
}