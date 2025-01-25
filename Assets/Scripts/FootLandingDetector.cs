using UnityEngine;

public class FootLandingDetector : MonoBehaviour {
    private const string BUBBLE_TAG = "Bubble";

    [SerializeField] private GameObject Player;

    private PlayerJump playerJump;
    private PlayerAnimation playerAnimation;
    void Start() {
        playerJump = Player.GetComponent<PlayerJump>();
        playerAnimation = Player.GetComponent<PlayerAnimation>();
    }
    void OnTriggerEnter2D(Collider2D trigger) {
        // �V���{���ʂɐڐG
        if (trigger.gameObject.tag == BUBBLE_TAG)
        {
            Debug.Log("TatchToBubble");
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
