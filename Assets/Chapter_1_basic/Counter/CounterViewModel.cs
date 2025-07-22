using UnityEngine;
using Zenject;

public class CounterViewModel
{
    private readonly CounterModel _model;

    [Inject]
    public CounterViewModel(CounterModel model)
    {
        _model = model;
    }

    public void Increment()
    {
        _model.Add(1);
        Debug.Log($"Count: {_model.GetCount()}");
    }

    public int GetCount() => _model.GetCount();
}
