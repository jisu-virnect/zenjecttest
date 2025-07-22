using UnityEngine;

public class CounterModel
{
    public int Count { get; private set; }

    public int GetCount() => Count;

    public void Add(int amount) => Count += amount;

    public void Reset() => Count = 0;
}
