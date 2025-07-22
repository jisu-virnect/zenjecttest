using UnityEngine;
using Zenject;

public class HelloStarter : MonoBehaviour
{
    [Inject] private Greeter _greeter;
    void Start()
    {
        _greeter.SayHello();
    }
}
