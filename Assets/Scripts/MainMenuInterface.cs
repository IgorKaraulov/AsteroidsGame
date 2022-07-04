using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInterface : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene(Constants.gameSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
