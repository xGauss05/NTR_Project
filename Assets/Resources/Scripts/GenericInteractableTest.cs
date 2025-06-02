using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteractableTest : MonoBehaviour, IInteractable
{
    [SerializeField] string UiInteractText;
    public string interactableText => UiInteractText;
    public bool canInteract { get; set; } = true;

    public void Interact(Interactor interactor)
    {
        Debug.Log("Interacting with: " + gameObject.name);
    }
}
