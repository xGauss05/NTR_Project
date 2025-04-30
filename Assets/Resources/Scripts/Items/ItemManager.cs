using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Inventory _playerInventory;
    [SerializeField] private ItemSO[] _startingItems;

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

        foreach (var item in _startingItems)
        {
            GiveItemToPlayer(item);
        }
    }

    public void GiveItemToPlayer(ItemSO item)
    {
        if (_playerInventory.IsInInventory(item.itemID)) return;

        _playerInventory.AddItem(item);
    }

    public bool CheckItemInPlayer(ItemSO item)
    { return _playerInventory.IsInInventory(item.itemID); }

    public void RemoveItemFromPlayer(uint itemID)
    {
        if (_playerInventory.IsInInventory(itemID))
            _playerInventory.RemoveItem(itemID);
    }
}