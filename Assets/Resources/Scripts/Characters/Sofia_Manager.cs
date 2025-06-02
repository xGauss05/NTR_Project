using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Sofia_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    public bool canInteract { get; set; } = false;

    //[SerializeField] NPCConversation dialogue;

    public void Interact(Interactor interactor)
    {

    }
}
