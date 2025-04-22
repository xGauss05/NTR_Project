using UnityEngine;

public class ItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO item;

    public string interactableText { get; private set; }

    void Awake()
    {
        interactableText = item.name;
    }

    public void Interact(Interactor interactor)
    {
        ItemManager.Singleton.GiveItemToPlayer(item);
    }
}