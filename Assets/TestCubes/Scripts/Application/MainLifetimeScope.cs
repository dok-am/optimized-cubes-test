using CubeTest.Factories;
using CubeTest.Instances;
using CubeTest.Managers;
using CubeTest.UI.Controllers;
using TriInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CubeTest.Application
{
    public class MainLifetimeScope : LifetimeScope
    {
        [SerializeField, Required] private SceneContext _sceneContext;
        [SerializeField, Required] private UIContext _uiContext;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_sceneContext);
            builder.RegisterInstance(_uiContext);

            builder.Register(container =>
            {
                SceneContext context = container.Resolve<SceneContext>();
                return new CubeFactory<CubeInstance>(context.CubePrefab, context.ObjectsContainer);
            }, Lifetime.Singleton);

            builder.Register(container =>
            {
                SceneContext context = container.Resolve<SceneContext>();
                return new CubeFactory<PlayerCubeInstance>(context.PlayerCubePrefab, context.ObjectsContainer);
            }, Lifetime.Singleton);


            builder.RegisterEntryPoint<InputManager>();

            builder.Register<PlayerManager>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
            builder.Register<CubeManager>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
            builder.Register<CubesConnectionManager>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
            builder.Register<BallsManager>(Lifetime.Scoped).AsSelf();

            builder.RegisterEntryPoint<DistanceViewController>();
            builder.RegisterEntryPoint<ImagesWindowController>();

            builder.RegisterEntryPoint<MainEntryPoint>();
        }
    }
}