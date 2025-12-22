using R3;
using TMPro;
using UnityEngine;

public class StudentView : MonoBehaviour
{
    [SerializeField] private TMP_Text idx;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text age;

    private StudentViewModel viewModel;

    public void SetViewModel(StudentViewModel viewModel)
    {
        this.viewModel = viewModel;
        viewModel.Idx.Subscribe(idx => this.idx.text = idx.ToString()).RegisterTo(destroyCancellationToken);
        viewModel.Name.Subscribe(name => this.name.text = name).RegisterTo(destroyCancellationToken);
        viewModel.Age.Subscribe(age => this.age.text = age.ToString()).RegisterTo(destroyCancellationToken);
    }
}
