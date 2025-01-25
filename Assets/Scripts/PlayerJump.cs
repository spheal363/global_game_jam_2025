using UnityEngine;

public class PlayerJump : MonoBehaviour {
    // 大ジャンプだと判断するまでの時間
    [SerializeField] private float longJumpTime = 2.0f;

    // 普通のジャンプ力
    [SerializeField] private float jumpPower = 5.0f;

    // 大ジャンプ力
    [SerializeField] private float longJumpPower = 10.0f;

    // PlayerのRigidbody2D
    private Rigidbody2D rb;

    // 現在ジャンプ中かどうか
    public bool isJumping = false;

    // 大ジャンプかどうか
    private bool isLongJump = false;

    public enum JumpKinds {
        Normal,
        Long
    }

    void Start() {
        // PlayerのRigidbody2Dを取得
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void Jump(JumpKinds jumpKinds) {
        // 普通のジャンプ
        if (jumpKinds == JumpKinds.Normal) {
            rb.linearVelocity = new Vector2(0, jumpPower);
            Debug.Log("普通ジャンプ");
        }
        // 大ジャンプ
        else if (jumpKinds == JumpKinds.Long) {
            rb.linearVelocity = new Vector2(0, longJumpPower);
            isLongJump = true;
            Debug.Log("大ジャンプ");
        }
    }
    public float getLongJumpTime() {
        return longJumpTime;
    }
    public bool GetisLongJumping() {
        return isLongJump;
    }
}