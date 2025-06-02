using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Francisco_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    //[SerializeField] NPCConversation dialogue;

    public void Interact(Interactor interactor)
    {

    }
}
