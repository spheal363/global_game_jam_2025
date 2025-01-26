using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool isGameOver = false;
    public GameObject gameOverCanvas;
    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void OnGameOver()
    {
        isGameOver = true;
        gameOverCanvas.SetActive(true);
    }

}
