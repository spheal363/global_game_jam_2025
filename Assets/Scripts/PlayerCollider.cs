using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private const string BUG_TAGS = "Bug";
    private const string GOAL_TAGS = "Goal";
    public GameOver gameOver;
    public GameObject clearCanvas;
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag(BUG_TAGS))
    //     {
    //         gameOver.OnGameOver();
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(BUG_TAGS))
        {
            gameOver.OnGameOver();
        }
        if (collider.gameObject.CompareTag(GOAL_TAGS))
        {
            Debug.Log("ゴールしました");
            clearCanvas.SetActive(true);
        }
    }
}
