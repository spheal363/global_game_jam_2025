using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    private Camera camera;   // カメラの参照
    public Vector3 mainFixedPosition; // 固定位置（必要に応じて）
    public float moveDuration = 1.0f; // カメラ移動時間
    public Ease moveEase = Ease.InOutQuad; // アニメーションのイージング

    private bool isMoving = false; // カメラ移動中のフラグ

    private void Start()
    {
        camera = GetComponent<Camera>();
        if (camera == null)
        {
            Debug.LogError("Camera component not found on this GameObject!");
        }
    }

    private void Update()
    {
        if (player != null && camera != null && !isMoving)
        {
            // プレイヤーの位置をビューポート座標に変換
            Vector3 viewportPos = camera.WorldToViewportPoint(player.position);

            // 画面外かどうかを判定
            if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
            {
                Debug.Log("Player is out of the screen!");
                HandlePlayerOutOfScreen();
            }
        }
    }

    private void HandlePlayerOutOfScreen()
    {
        // プレイヤーが画面外に出たときの処理
        Debug.Log("プレイヤーが画面外に出た");

        // フラグを立てる（再び Update で呼ばれないようにする）
        isMoving = true;

        // 必要に応じて再配置や他の処理を実行
        camera.transform.DOMove(mainFixedPosition, moveDuration)
            .SetEase(moveEase)
            .OnComplete(() => isMoving = false); // アニメーション終了後にフラグをリセット
    }
}
