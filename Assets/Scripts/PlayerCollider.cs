using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private const string BUG_TAGS = "Bug";
    public GameOver gameOver;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(BUG_TAGS))
        {
            gameOver.OnGameOver();
        }
    }
}
