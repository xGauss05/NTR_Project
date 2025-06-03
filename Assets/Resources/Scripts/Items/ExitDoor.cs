using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    [SerializeField] private ItemSO itemToOpen;

    public bool canInteract { get; set; } = false;

    public void Interact(Interactor interactor)
    {
        if (ItemManager.Singleton.CheckItemInPlayer(itemToOpen))
        {
            Transitioner.Singleton.FadeToBlack("3_Escape");
        }
        else
        {
            Debug.Log("Bobo you dont have object");
        }
    }
}