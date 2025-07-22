using UnityEngine;
using Zenject;

public class CounterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CounterModel>().AsSingle();
        Container.Bind<CounterViewModel>().AsSingle();
    }
}
