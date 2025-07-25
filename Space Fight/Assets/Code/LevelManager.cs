using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class LevelManager : MonoBehaviour
{
    //Refrences
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();   
    }

  public void LoadMainMenu()
    {
        //Loads Game Scene
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        //Loads Game Scene
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        if (scoreKeeper != null) { scoreKeeper.ResetScore(); }
        
    }

    public void LoadLeaderboard()
    {
        //Loads leaderboard scene
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
