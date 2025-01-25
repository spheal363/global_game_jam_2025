using UnityEngine;

public class PlayerMove : MonoBehaviour {
    // �v���C���[�̈ړ����x
    [SerializeField] private float moveSpeed = 1.0f;

    public void MoveLeft() {
        this.gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        // Player��Y��Rotation��0�ɂ��č�������
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MoveRight() {
        this.gameObject.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        // Player��Y��Rotation��180�ɂ��ĉE������
        this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}