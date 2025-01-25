using UnityEngine;

public class FootLandingDetector : MonoBehaviour {
    private const string BUBBLE_TAG = "Bubble";

    [SerializeField] private GameObject Player;
    private PlayerJump playerJump;

    void Start() {
        playerJump = Player.GetComponent<PlayerJump>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // �V���{���ʂɐڐG
        if (collision.gameObject.tag == BUBBLE_TAG) {
            playerJump.isJumping = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        // �v���C���[����W�����v�������ꍇ�A�����̃V���{���ʂ��폜
        if (playerJump.GetisLongJumping() && collision.gameObject.tag == BUBBLE_TAG) {
            DestroyBubble(collision.gameObject);
        }
    }

    // �V���{���ʂ̃Q�[���I�u�W�F�N�g����
    public void DestroyBubble(GameObject bubble) {
        Destroy(bubble);
    }
}
