using CubeTest.Factories;
using CubeTest.Instances;
using CubeTest.Managers;
using TriInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CubeTest.Application
{
    public class MainLifetimeScope : LifetimeScope
    {
        [SerializeField, Required] private SceneContext _sceneContext;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_sceneContext);

            builder.Register(resolver =>
            {
                SceneContext context = resolver.Resolve<SceneContext>();
                return new CubeFactory<CubeInstance>(context.CubePrefab, context.ObjectsContainer);
            }, Lifetime.Singleton);

            builder.Register(resolver =>
            {
                SceneContext context = resolver.Resolve<SceneContext>();
                return new CubeFactory<PlayerCubeInstance>(context.PlayerCubePrefab, context.ObjectsContainer);
            }, Lifetime.Singleton);


            builder.RegisterEntryPoint<InputManager>();

            builder.Register<PlayerManager>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
            builder.Register<CubeManager>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();
            builder.Register<CubesConnectionManager>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();

            builder.RegisterEntryPoint<MainEntryPoint>();
        }
    }
}