using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    // スペースキーが押されている間
    private const string IS_SPACE_PRESSED = "isSpacePressed";
    // ジャンプ中
    private const string IS_JUMPING = "isJumping";
    // 着地した
    private const string IS_JUMP_FINISHED = "isJumpFinished";
    // 棒立ちに戻る
    private const string IS_RESET_STATE = "isResetState";

    private void Start() {
        animator = this.GetComponent<Animator>();
    }
    public void SetIsSpacePressed(bool isSpacePressed) {
        animator.SetBool(IS_SPACE_PRESSED, isSpacePressed);
    }
    public void SetIsJumping(bool isJumping) {
        animator.SetBool(IS_JUMPING, isJumping);
        // 一つ前のフラグをリセット
        animator.SetBool(IS_SPACE_PRESSED, false);
    }
    public void SetIsJumpFinished(bool isJumpFinished) {
        animator.SetBool(IS_JUMP_FINISHED, isJumpFinished);
        // 一つ前のフラグをリセット
        animator.SetBool(IS_JUMPING, false);
    }

    public void SetIsResetState(bool isResetState) {
        animator.SetBool(IS_RESET_STATE, isResetState);
        // 一つ前のフラグをリセット
        animator.SetBool(IS_JUMP_FINISHED, false);
    }
}
