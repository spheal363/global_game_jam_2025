using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController:MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

