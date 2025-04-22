using UnityEngine;

public class ItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO item;

    [SerializeField] private bool startingInventoryState;

    public string interactableText { get; private set; }

    void Awake()
    {
        interactableText = item.name;
        item.inInventory = startingInventoryState;

        if(startingInventoryState)
        {
            ItemManager.Singleton.GiveItemToPlayer(item);
        }
    }

    public void Interact(Interactor interactor)
    {
        ItemManager.Singleton.GiveItemToPlayer(item);
    }
}

