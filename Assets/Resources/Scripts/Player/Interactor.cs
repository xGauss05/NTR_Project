using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] float interactDistance = 1.5f;

    [SerializeField] GameObject interactText;

    private PlayerMovement playerMovement;
    private CameraController cameraController;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        cameraController = GetComponent<CameraController>();
    }

    void Update()
    {
        if (DialogueEditor.ConversationManager.Instance.IsConversationActive)
        {
            playerMovement.enabled = false;
            cameraController.enabled = false;

            Cursor.lockState = CursorLockMode.None;

            SetInteractText(false);

            return;
        }

        playerMovement.enabled = true;
        cameraController.enabled = true;

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
