using UnityEngine;

public class ItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO item;

    public string interactableText { get; private set; }
    public bool canInteract { get; set; } = true;

    [SerializeField] Sofia_Manager sofiaManager;
    void Awake()
    {
        interactableText = item.name;
    }

    public void Interact(Interactor interactor)
    {
        ItemManager.Singleton.GiveItemToPlayer(item);
        gameObject.SetActive(false);
        sofiaManager.canInteract = true;
    }
}