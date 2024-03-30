using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static void MainMenu()
    {
        SceneManager.LoadSceneAsync("Scenes/MainMenu");
    }

    public static void StartGame()
    {
        SceneManager.LoadSceneAsync("Scenes/SampleScene");
    }

    public static void GameOver()
    {
        SceneManager.LoadSceneAsync("Scenes/GameOver");
    }

    public static void GameFinished()
    {
        SceneManager.LoadSceneAsync("Scenes/GameFinished");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}