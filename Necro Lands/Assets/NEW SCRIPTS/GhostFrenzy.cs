using UnityEngine;
using System.Collections;

public class GhostFrenzy : DefendingFrenzy 
{
    public int kills;
    public int requiredKills;
    public string keyName;

    void Update()
    {
        if (kills >= requiredKills && !GameManager.Win)
        {
            GameManager.Win = true;
            if (GameManager.Lose)
                GameManager.Lose = false;
        }
    }
    public override void EndingTask()
    {
        if (kills < requiredKills)
            GameManager.Lose = true;
    }
}
