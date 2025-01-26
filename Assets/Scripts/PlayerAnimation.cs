using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    // �X�y�[�X�L�[��������Ă����
    private const string IS_SPACE_PRESSED = "isSpacePressed";
    // �W�����v��
    private const string IS_JUMPING = "isJumping";
    // ���n����
    private const string IS_JUMP_FINISHED = "isJumpFinished";
    // �_�����ɖ߂�
    private const string IS_RESET_STATE = "isResetState";
    private const string IS_MOVE_STATE = "isMoveState";
    public float horizontalInput;

    private void Start() {
        animator = this.GetComponent<Animator>();
    }
    public void SetIsSpacePressed(bool isSpacePressed) {
        animator.SetBool(IS_SPACE_PRESSED, isSpacePressed);
        // ��O�̃t���O�����Z�b�g
        animator.SetBool(IS_RESET_STATE, false);
    }
    public void SetIsJumping(bool isJumping) {
        animator.SetBool(IS_JUMPING, isJumping);
        // ��O�̃t���O�����Z�b�g
        animator.SetBool(IS_SPACE_PRESSED, false);
    }
    public void SetIsJumpFinished(bool isJumpFinished) {
        animator.SetBool(IS_JUMP_FINISHED, isJumpFinished);
        // ��O�̃t���O�����Z�b�g
        animator.SetBool(IS_JUMPING, false);
    }

    public void SetIsResetState(bool isResetState) {
        animator.SetBool(IS_RESET_STATE, isResetState);
        // ��O�̃t���O�����Z�b�g
        animator.SetBool(IS_JUMP_FINISHED, false);
    }

    public void SetIsMoveTrue()
    {
        animator.SetBool(IS_MOVE_STATE, true);
    }

    public void SetIsMoveFalse()
    {
        animator.SetBool(IS_MOVE_STATE, false);
    }
}
