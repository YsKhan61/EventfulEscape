using UnityEngine;

[CreateAssetMenu(fileName = "StringData", menuName = "ScriptableObjects/StringDataSO")]
public class StringDataSO : ScriptableObject
{
    [SerializeField, TextArea(1,10)]
    private string value;

    public string Value => value;
}
