using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller, IInitializable
{
    // public override void InstallBindings()
    // {
    //     Debug.Log("HelloWorld");

    //     Container.BindInstance("bbbbbbbbbbbb");
    //     Container.BindInstance(2025);

    //     //Container.BindInstance(new ttt() { message = "None withid" }).AsSingle().NonLazy();
    //     Container.Bind<ttt>().WithId(1).FromInstance(new ttt(){message = "withid 1"}).AsCached();
    //     Container.Bind<ttt>().WithId(2).FromInstance(new ttt(){message = "withid 2"}).AsCached();
    //     // Container.Bind<ttt>().AsSingle().NonLazy();



    //     // Container.Bind<Greeter2>().FromInstance(new Greeter2()).AsSingle().NonLazy();
    //     Container.Bind<string>().FromInstance("ccccccccccc");

    //     Container.Bind<Greeter2>().AsSingle().NonLazy();
    // }


    public override void InstallBindings()
    {
        Debug.Log("HelloWorld");


        // Container.BindInstance(new string("bbbbbbbbbbbb"));
        // Container.BindInstance(2025);
        // Container.BindInstance(new Greeter2());

        // Container.Bind<ttt>().WithId(1).FromInstance(new ttt() { message = "withid 1" }).AsCached();
        // Container.Bind<ttt>().WithId(2).FromInstance(new ttt() { message = "withid 2" }).AsCached();

        // Container.Bind<Greeter2>().FromResolve().NonLazy();
        // Container.Resolve<Greeter2>();

        // ttt = Container.Resolve<ttt>();
        // Container.Inject(new ttt());
        // Container.Bind<ttt>().AsTransient();
        // Container.Bind<IInitializable>().FromInstance(this).AsTransient();

        // Container.Bind<Greeter2>().FromInstance(new Greeter2()).AsSingle().NonLazy();


        Container.BindInstance<string>("bbbbbbbbbbbb");
        Container.BindInstance<int>(2025);

        // var v = new Greeter2();
        // Container.Inject(v);
        // Container.BindInstance(v);
        // Container.Bind<Greeter2>();
        // Container.Bind<Greeter2>().AsCached();
        Container.Bind<Greeter2>().AsTransient();
        // Container.Resolve<Greeter2>();
        // Container.Bind<Greeter2>().AsSingle().NonLazy();
        // Container.Bind<Greeter2>().FromInstance(new Greeter2()).AsSingle().NonLazy();
    }
    ttt ttt;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Container.Resolve<Greeter2>();
            // Container.Rebind<Greeter2>();
        }
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     Container.Inject(ttt);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     Debug.Log(ttt.message);
        // }
    }

    public void Initialize()
    {
        //Debug.Log(ttt.message);
        // Container.Inject(new ttt());
    }

}

