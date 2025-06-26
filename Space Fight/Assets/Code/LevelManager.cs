using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    public void LoadMainMenu()
    {
        //Loads Game Scene
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        //Loads Game Scene
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
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
