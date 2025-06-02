using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] float interactDistance = 1.5f;

    [SerializeField] GameObject interactText;

    void Update()
    {
        if (DialogueEditor.ConversationManager.Instance.IsConversationActive)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<CameraController>().enabled = false;

            Cursor.lockState = CursorLockMode.None;

            SetInteractText(false);

            return;
        }

        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<CameraController>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;

        UpdateInteractText();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GetInteractable() != null && GetInteractable().canInteract)
                GetInteractable()?.Interact(this);
        }
    }

    public void SetInteractText(bool active, string text = "")
    {
        interactText.SetActive(active);

        if (text == "") { return; }

        TMPro.TMP_Text textToChange = interactText.GetComponent<TMPro.TMP_Text>();

        textToChange.text = text;

        interactText.GetComponent<RectTransform>().sizeDelta = new Vector2(textToChange.preferredWidth, textToChange.preferredHeight);
    }

    void UpdateInteractText()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hitInfo, interactDistance, ~0, QueryTriggerInteraction.Ignore) &&
            hitInfo.transform.GetComponent<IInteractable>() != null &&
            GetInteractable().canInteract)
        {
            SetInteractText(true, hitInfo.transform.GetComponent<IInteractable>().interactableText);
        }
        else
        {
            SetInteractText(false);
        }
    }

    IInteractable GetInteractable()
    {
        if (!Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hitInfo, interactDistance, ~0, QueryTriggerInteraction.Ignore)) return null;

        return hitInfo.collider.gameObject.GetComponent<IInteractable>();
    }
}
