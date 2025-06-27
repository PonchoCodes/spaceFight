using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;
using Unity.VisualScripting;
public class Leaderboard : MonoBehaviour
{
    [Header("Leaderboard")]
    [SerializeField] List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;
    string publicLeaderboardKey = "45e91f9b29be1fe9ee94970813ecf55d95a8d2bd8bd729e074de0a4c197cf2e9";

    public void getLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLBEntry(string username, int score)
    {
        // To add if lb entries still don't allow for more than one after release: LeaderboardCreator.ResetPlayer()
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {
            getLeaderboard();
        }));
    }

    private void Start()
    {
        getLeaderboard();   
    }
}
