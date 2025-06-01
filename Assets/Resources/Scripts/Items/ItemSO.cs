using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;

    [TextArea(4, 100)]
    public string description;

    public uint itemID;
}