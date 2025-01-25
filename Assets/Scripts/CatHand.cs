using UnityEngine;

public class CatHand:MonoBehaviour
{
    public float speed = 2f; // 移動速度
    public float resetYPosition = -6f; // 初期位置のY座標（画面外下側）
    public float startYPosition = 6f;  // 終了後に戻るY座標（画面外上側）

    private Vector2 direction = Vector2.up; // 移動方向（デフォルトは上方向）
    private bool isMovingDown = false; // 下方向に動いているかのフラグ

    void Update()
    {
        // 現在の方向に移動
        transform.Translate(direction * speed * Time.deltaTime);

        // 上方向の移動中に画面外（上）に出た場合、初期位置にリセット
        if (!isMovingDown && transform.position.y > startYPosition)
        {
            ResetPosition();
        }

        // 下方向の移動中に画面外（下）に出た場合、初期位置にリセット
        if (isMovingDown && transform.position.y < resetYPosition)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // ランダムなX座標で初期化し、上方向の移動に戻す
        float randomX = Random.Range(-8.0f, 8.0f); // 画面内のX座標範囲を設定
        transform.position = new Vector2(randomX, resetYPosition);
        direction = Vector2.up; // 上方向にリセット
        isMovingDown = false;  // 下方向フラグを解除
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Bubbleタグを持つオブジェクトに触れた場合
        if (other.CompareTag("Bubble"))
        {
            // 下方向に移動を切り替える
            direction = Vector2.down;
            isMovingDown = true;
        }
    }








}
