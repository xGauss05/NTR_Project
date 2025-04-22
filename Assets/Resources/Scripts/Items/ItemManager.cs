using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Inventory _playerInventory;

    public static ItemManager Singleton;

    private void Awake()
    {
        #region Singleton

        if (Singleton != null && Singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Singleton = this;
        }

        DontDestroyOnLoad(this.gameObject);

        #endregion Singleton
    }

    public void GiveItemToPlayer(ItemSO item)
    {
        if (item.inInventory) return;

        _playerInventory.AddItem(item);
        item.inInventory = true;
    }

    public void RemoveItemFromPlayer(uint itemID)
    {
        _playerInventory.RemoveItem(itemID);
    }
}
