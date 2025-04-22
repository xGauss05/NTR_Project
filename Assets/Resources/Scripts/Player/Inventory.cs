using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<uint, ItemSO> _inventory = new();

    public void AddItem(ItemSO itemToAdd)
    {
        _inventory.Add(itemToAdd.itemID, itemToAdd);

        Debug.Log(_inventory.Count);
    }

    public void RemoveItem(uint itemID)
    {
        _inventory.Remove(itemID);
    }
}
