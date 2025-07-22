using UnityEngine;
using Zenject;

public class BasicInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance("Hello from Zenject!");
        Container.Bind<Greeter>().AsSingle().NonLazy();
    }
}


