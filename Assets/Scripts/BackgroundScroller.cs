using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    [Header("背景画像のスクロール速度 = 強制スクロールの速度")] public float scrollSpeed = 0.01f;

    [Header("画像のスクロール終了地点")] public float stopPosition = -19.2f;

    [Header("画像の再スタート地点")] public float restartPosition = 38.4f;

    [Header("背景画像のリスト")] public List<GameObject> backgrounds;

    [SerializeField] private CameraManager cameraManager;

    void Update() {
        // カメラが移動したかどうかのフラグがtrueの場合
        if (cameraManager.getHasMoved()) {
            // 強制スクロールを実行
            ForceScroll();
        }
    }

    // 強制スクロールを実行するメソッド
    void ForceScroll() {
        // すべての背景画像に対して処理を行う
        foreach (GameObject background in backgrounds) {
            // 背景画像の位置を更新
            background.transform.position += new Vector3(-scrollSpeed, 0, 0);
            // 背景画像がスクロール終了地点を超えた場合
            if (background.transform.position.x < stopPosition) {
                // 背景画像を再スタート地点に移動
                background.transform.position = new Vector3(restartPosition, background.transform.position.y,
                    background.transform.position.z);
            }
        }
    }
}