using UnityEngine;
using Zenject;

public class Greeter2
{
    // [Inject]
    // public void SayHelloMulti([Inject(Id = 1)] ttt message, [Inject(Id = 2)] ttt message2) // 1번 인스턴스
    // {
    //     Debug.Log(message.message);
    //     Debug.Log(message2.message);

    //     Debug.Log(message3);
    // }

    // [Inject]
    // string message3;


    // // [Inject]
    // // public void SayHello1(ttt message) // 1번 인스턴스
    // // {
    // //     Debug.Log(message.message);
    // // }

    // [Inject]
    // public void SayHello1([Inject(Id = 1)] ttt message) // 1번 인스턴스
    // {
    //     Debug.Log(message.message);
    // }
    // [Inject]
    // public void SayHello2([Inject(Id = 2)] ttt message) // 1번 인스턴스
    // {
    //     Debug.Log(message.message);
    // }
    // public Greeter2() { }
    [Inject]
    public void SayHelloString(string message)
    {
        Debug.Log("Greeter2 string message : " + message);
    }

    [Inject]
    public void SayHelloInt(int message)
    {
        Debug.Log("Greeter2 int message : " + message);
    }
}
