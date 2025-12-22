using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Greeter2Service : MonoBehaviour
{
    [Inject] private DiContainer container;
    // [Inject] private Greeter2 greeter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var v = container.Resolve<Greeter2>();
            v.SayHelloString("hihi");
            
            // greeter.SayHelloString("hihi");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("jhjo2");
        }
        //     if (Input.GetKeyDown(KeyCode.Alpha2))
        //     {
        //         greeter.SayHello1(new ttt() { message = "22222222222222222222222" });
        //     }
        //     if (Input.GetKeyDown(KeyCode.Alpha3))
        //     {
        //         greeter.SayHello2(new ttt() { message = "33333333333" });
        //     }
        //     if (Input.GetKeyDown(KeyCode.Alpha4))
        //     {
        //         greeter.SayHelloMulti(new ttt() { message = "4444444" }, new ttt() { message = "55555555" });
        //     }
        //     if (Input.GetKeyDown(KeyCode.Alpha5))
        //     {
        //         greeter.SayHelloInt(100);
        //     }
    }
}
