using System.Reflection;
using System.Xml.Serialization;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    //References
    UIDisplay uIDisplay;

    private void Awake()
    {
        uIDisplay = FindFirstObjectByType<UIDisplay>();
    }
    
    private void Start()
    {
          uIDisplay.UpdateScore(score);
    }

    public void ModifyScore(int points)
    {
        score += points;
        Mathf.Clamp(score, 0, float.MaxValue);
        uIDisplay.UpdateScore(score);
    }

    public void resetScore()
    {
        score = 0;
    }

    // Getter methods
    public int getScore()
    {
        return score;
    }
}
