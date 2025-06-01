using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] const float rotSpeed = 15.0f;
    [SerializeField] NPCConversation cinematicDialogue;
    
    private void Start()
    {
        ConversationManager.Instance.StartConversation(cinematicDialogue);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 rot = new Vector3(0, rotSpeed * Time.deltaTime, 0);
        gameObject.transform.Rotate(rot);
    }
}
