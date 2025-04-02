using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Singleton { get; private set; }

    List<QuestSO> quests;
    List<QuestSO> completedQuests;

    private void Awake()
    {
        #region Singleton

        if (Singleton != null && Singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Singleton = this;
        }

        DontDestroyOnLoad(this.gameObject);

        #endregion Singleton
    }
    
    public void AddQuest(QuestSO questSO)
    {
        questSO.quest.progress = QuestSO.QuestProgress.Started;
        quests.Add(questSO);
    }

}
