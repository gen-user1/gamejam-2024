using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static void StartGame()
    {
        SceneManager.LoadSceneAsync("Scenes/SampleScene");
    }
    
    public static void GameOver()
    {
        SceneManager.LoadSceneAsync("Scenes/GameOver");
    }
}