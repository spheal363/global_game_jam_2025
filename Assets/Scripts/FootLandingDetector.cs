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
        // �V���{���ʂɐڐG
        if (trigger.gameObject.tag == BUBBLE_TAG || trigger.gameObject.tag == GOUND_TAG)
        {
            Debug.Log("���n");
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
