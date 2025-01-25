using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    [SerializeField] Transform player; // プレイヤーのTransform
    [SerializeField] Transform cameraMovePoint; // カメラ移動ポイントのTransform
    private bool hasMoved = false; // カメラが移動したかどうかのフラグ

    void Update() {
        // プレイヤーがCameraMovePointのxを超えた場合
        if (!hasMoved && player.position.x > cameraMovePoint.position.x) {
            hasMoved = true; // フラグをtrueに設定
            StartCoroutine(MoveCameraToPosition(new Vector3(9.2f, transform.position.y, transform.position.z), 0.5f));
        }
    }

    // カメラを指定した位置に移動させるコルーチン
    private IEnumerator MoveCameraToPosition(Vector3 targetPosition, float duration) {
        Vector3 startPosition = transform.position; // 現在のカメラ位置
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            // 線形補間を使用して位置を更新
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // 次のフレームまで待機
        }

        // 最終的に正確にターゲット位置に設定
        transform.position = targetPosition;
    }

    public bool getHasMoved()
    {
        return hasMoved;
    }
}