using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    private Camera camera;   // カメラの参照
    public Vector2 mainFixedPosition; // 固定位置（必要に応じて）

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
        if (player != null && camera != null)
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
        Debug.Log("Handling player out of screen event.");

        // 必要に応じて再配置や他の処理を実行
        // 例: プレイヤーを画面内の固定位置に戻す
        player.position = new Vector3(mainFixedPosition.x, mainFixedPosition.y, player.position.z);
    }
}
