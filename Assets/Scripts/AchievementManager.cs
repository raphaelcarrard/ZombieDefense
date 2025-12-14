using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class AchievementManager : MonoBehaviour
{
    
    public static AchievementManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CheckAchievements()
    {
        if(PlayerPrefs.GetInt("day") >= 15)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement15Days, 100f, (bool success) => { });
        }
        if(PlayerPrefs.GetInt("totalkill") >= 100)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement100Kills, 100f, (bool success) => { });
        }
        if(PlayerPrefs.GetInt("totalgun") >= 3)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement4Guns, 100f, (bool success) => { });
        }
        if(PlayerPrefs.GetInt("money") >= 30000)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement30KMoney, 100f, (bool success) => { });
        }
        if(PlayerPrefs.GetInt("day") >= 30)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement30Days, 100f, (bool success) => { });
        }
    }
}
