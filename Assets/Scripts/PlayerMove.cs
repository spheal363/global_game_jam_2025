using UnityEngine;

public class PlayerMove : MonoBehaviour {
    // �v���C���[�̈ړ����x
    [SerializeField] private float moveSpeed = 1.0f;

    public void MoveLeft() {
        this.gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    public void MoveRight() {
        this.gameObject.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}