using UnityEngine;

public class FootLandingDetector : MonoBehaviour {
    private const string BUBBLE_TAG = "Bubble";

    [SerializeField] private GameObject Player;
    private PlayerJump playerJump;

    void Start() {
        playerJump = Player.GetComponent<PlayerJump>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // シャボン玉に接触
        if (collision.gameObject.tag == BUBBLE_TAG) {
            playerJump.isJumping = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        // プレイヤーが大ジャンプをした場合、足元のシャボン玉を削除
        if (playerJump.GetisLongJumping() && collision.gameObject.tag == BUBBLE_TAG) {
            DestroyBubble(collision.gameObject);
        }
    }

    // シャボン玉のゲームオブジェクトを壊す
    public void DestroyBubble(GameObject bubble) {
        Destroy(bubble);
    }
}
