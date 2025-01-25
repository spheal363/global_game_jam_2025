using UnityEngine;

public class FootLandingDetector : MonoBehaviour {
    private const string BUBBLE_TAG = "Bubble";
    private const string GOUND_TAG = "Ground";

    [SerializeField] private GameObject Player;

    private PlayerJump playerJump;
    private PlayerAnimation playerAnimation;
    void Start() {
        playerJump = Player.GetComponent<PlayerJump>();
        playerAnimation = Player.GetComponent<PlayerAnimation>();
    }
    void OnTriggerEnter2D(Collider2D trigger) {
        // シャボン玉に接触
        if (trigger.gameObject.tag == BUBBLE_TAG || trigger.gameObject.tag == GOUND_TAG)
        {
            Debug.Log("着地");
            playerJump.isJumping = false;
            playerAnimation.SetIsJumpFinished(true);
        }
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        playerAnimation.SetIsResetState(true);
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        playerAnimation.SetIsResetState(false);
        // プレイヤーが大ジャンプをした場合、足元のシャボン玉を削除
        if (playerJump.GetisLongJumping() && trigger.gameObject.tag == BUBBLE_TAG) {
            DestroyBubble(trigger.gameObject);
        }
    }

    // シャボン玉のゲームオブジェクトを壊す
    public void DestroyBubble(GameObject bubble) {
        Destroy(bubble);
    }
}
