using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestSO questToGive;

    public void GiveQuest(GameObject player)
    {
        if (QuestManager.Singleton != null)
        {
            QuestManager.Singleton.AddQuest(questToGive);
        }
    }
}
