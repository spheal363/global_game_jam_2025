using UnityEngine;

public class FootLandingDetector : MonoBehaviour {
    private const string BUBBLE_TAG = "Bubble";
    private const string GOUND_TAG = "Ground";
    private const string GAMEOVER_TAG = "GameOver";

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject GameOverCanvas;
    public GameOver gameOver;

    private PlayerJump playerJump;
    private PlayerAnimation playerAnimation;
    void Start() {
        playerJump = Player.GetComponent<PlayerJump>();
        playerAnimation = Player.GetComponent<PlayerAnimation>();
        GameOverCanvas.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D trigger) {
        // �V���{���ʂɐڐG
        if (trigger.gameObject.tag == BUBBLE_TAG || trigger.gameObject.tag == GOUND_TAG)
        {
            Debug.Log("���n");
            playerJump.isJumping = false;
            playerAnimation.SetIsJumpFinished(true);
        }
        if (trigger.CompareTag(GAMEOVER_TAG))
        {
            Debug.Log("ゲームオーバー！");
            gameOver.OnGameOver();
        }
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        playerAnimation.SetIsResetState(true);
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        playerAnimation.SetIsResetState(false);
        // �v���C���[����W�����v�������ꍇ�A�����̃V���{���ʂ��폜
        if (playerJump.GetisLongJumping() && trigger.gameObject.tag == BUBBLE_TAG) {
            DestroyBubble(trigger.gameObject);
        }
    }

    // �V���{���ʂ̃Q�[���I�u�W�F�N�g����
    public void DestroyBubble(GameObject bubble) {
        Destroy(bubble);
    }
}
