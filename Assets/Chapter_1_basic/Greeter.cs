using UnityEngine;
using Zenject;

public class Greeter
{
    [Inject]
    private string _message;

    public void SayHello()
    {
        Debug.Log(_message);
    }
}
