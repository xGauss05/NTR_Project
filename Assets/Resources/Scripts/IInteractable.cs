using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string interactableText { get; }

    public void Interact(Interactor interactor);
}
