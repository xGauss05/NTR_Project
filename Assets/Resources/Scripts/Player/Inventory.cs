using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<uint, ItemSO> _inventory = new();

    public void AddItem(ItemSO itemToAdd)
    {
        _inventory.Add(itemToAdd.itemID, itemToAdd);
    }

    public void RemoveItem(uint itemID)
    {
        _inventory.Remove(itemID);
    }

    public bool IsInInventory(uint itemID)
    {
        return _inventory.ContainsKey(itemID);
    }
}