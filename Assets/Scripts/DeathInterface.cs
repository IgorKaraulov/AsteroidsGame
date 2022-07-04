using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathInterface : MonoBehaviour
{
    [SerializeField]
    private Text finalScoreText;


    public void AddScore(int result) 
    {
        finalScoreText.text = $"Your final score: {result}";
    }
    public void MainMenuButtonClick()
    {
        SceneManager.LoadScene(Constants.mainMenuSceneIndex);
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(Constants.gameSceneIndex);
    }
}
