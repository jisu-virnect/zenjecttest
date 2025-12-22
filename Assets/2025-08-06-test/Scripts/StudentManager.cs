using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    [SerializeField] private StudentView studentViewPrefab;
    [SerializeField] private Transform studentParent;

    public void SetStudents(List<StudentModel> models)
    {
        foreach (var model in models)
        {
            // 뷰모델 생성
            var viewModel = new StudentViewModel(model);
            
            // 뷰 생성
            var view = Instantiate(studentViewPrefab, studentParent);

            // 뷰모델 주입
            view.SetViewModel(viewModel);
        }
    }

    [SerializeField]
    private List<StudentModel> models;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetStudents(models);
        }
    }
}