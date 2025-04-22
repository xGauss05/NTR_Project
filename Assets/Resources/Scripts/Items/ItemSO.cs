using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string description;

    public uint itemID;
    public bool inInventory;
}