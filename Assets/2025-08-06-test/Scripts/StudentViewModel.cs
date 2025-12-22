using R3;

public class StudentViewModel
{
    private readonly StudentModel _model;

    public ReadOnlyReactiveProperty<int> Idx { get; }
    public ReadOnlyReactiveProperty<string> Name { get; }
    public ReadOnlyReactiveProperty<int> Age { get; }

    public StudentViewModel(StudentModel model)
    {
        _model = model;

        Idx = model.idx.ToReadOnlyReactiveProperty();
        Name = model.name.ToReadOnlyReactiveProperty();
        Age = model.age.ToReadOnlyReactiveProperty();
    }
}
