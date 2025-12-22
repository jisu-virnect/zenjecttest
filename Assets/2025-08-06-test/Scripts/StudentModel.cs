using UnityEngine;
using R3;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

[CreateAssetMenu(fileName = "StudentModel", menuName = "ScriptableObjects/StudentModel", order = 1)]
public class StudentModel : ScriptableObject
{
    [JsonIgnore]
    public SerializableReactiveProperty<int> idx = new(0);
    [JsonProperty(nameof(idx))]
    private int idxValue
    {
        get => idx.Value;
        set => idx.Value = value;
    }
    [JsonIgnore]
    public SerializableReactiveProperty<string> name = new("");
    [JsonProperty(nameof(name))]
    private string nameValue
    {
        get => name.Value;  
        set => name.Value = value;
    }
    [JsonIgnore]
    public SerializableReactiveProperty<int> age = new(0);
    [JsonProperty(nameof(age))]
    private int ageValue
    {
        get => age.Value;
        set => age.Value = value;
    }
}
