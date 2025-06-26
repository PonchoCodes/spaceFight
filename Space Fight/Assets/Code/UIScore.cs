using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    
    void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();    
    }

    
    void Start()
    {
        scoreText.text = scoreKeeper.getScore().ToString();    
    }
}
