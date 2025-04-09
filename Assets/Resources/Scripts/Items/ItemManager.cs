using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Dictionary<uint, ItemSO> items;

    public ItemSO[] itemPool;
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

        InitializeItemDictionary();
    }

    public bool RequestItem(uint itemKey)
    {
        if (!items.ContainsKey(itemKey)) return false;

        return true;
    }

    private void InitializeItemDictionary()
    {
        for (int i = 0; i < itemPool.Length; i++)
        { items.Add((uint)i, itemPool[i]); }
    }
}
