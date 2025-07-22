using TMPro;
using UnityEngine;
using Zenject;

public class CounterView : MonoBehaviour
{
    [Inject]
    private CounterViewModel _viewModel;

    [SerializeField]
    private TMP_Text _text;

    public void OnClick_Increment()
    {
        _viewModel.Increment();
        _text.text = _viewModel.GetCount().ToString();
    }
}
