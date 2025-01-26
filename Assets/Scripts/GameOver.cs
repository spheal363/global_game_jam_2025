using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool isGameOver = false;
    public GameObject gameOverCanvas;
    private const string MAIN_SCENE_NAME = "MainScene";
    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void OnGameOver()
    {
        isGameOver = true;
        gameOverCanvas.SetActive(true);
    }
    public void OnGameRetry()
    {
        SceneManager.LoadScene(MAIN_SCENE_NAME);
    }
}
