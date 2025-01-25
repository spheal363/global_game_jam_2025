using UnityEngine;

public class PlayerMove : MonoBehaviour {
    // プレイヤーの移動速度
    [SerializeField] private float moveSpeed = 1.0f;

    public void MoveLeft() {
        this.gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        // PlayerのYのRotationを0にして左向きに
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MoveRight() {
        this.gameObject.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        // PlayerのYのRotationを180にして右向きに
        this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}