using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Container.Bind<ttt>().FromNew();
        // Container.Bind<ttt>().FromInstance(new ttt()).AsSingle();

        // Container.BindInstance(new ttt());
        // Container.Bind<ttt>().AsSingle().NonLazy();

        
        // Container.BindInstance("bbbbbbbbbbbb");
        // Container.BindInstance(2025);
        // Container.Bind<Greeter2>().AsSingle().NonLazy();
        // Container.Bind<Greeter2>().AsSingle();
    }
}
