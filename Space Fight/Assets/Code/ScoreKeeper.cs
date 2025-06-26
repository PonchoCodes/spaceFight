using System.Reflection;
using System.Xml.Serialization;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    static ScoreKeeper instance;
    private int score = 0;
    //References
    UIDisplay uIDisplay;

    private void Awake()
    {
        uIDisplay = FindFirstObjectByType<UIDisplay>();
        ManageSingleton();
    }

    private void Start()
    {
        uIDisplay.UpdateScore(score);
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
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
