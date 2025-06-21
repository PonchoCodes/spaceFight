using System.Reflection;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ModifyScore(int points)
    {
        score += points;
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
