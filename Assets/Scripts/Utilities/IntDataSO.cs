using UnityEngine;

[CreateAssetMenu(fileName = "IntData", menuName = "ScriptableObjects/IntDataSO")]
public class IntDataSO : ScriptableObject
{
    [SerializeField]
    private int value;

    public int Value => value;
}
