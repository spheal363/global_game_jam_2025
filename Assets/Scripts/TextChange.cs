using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    private Text textMeshPro;
    [SerializeField] private float goalLen = 500.0f;

    void Start() {
        textMeshPro = GetComponent<Text>();
        textMeshPro.text = "ゴールまであと " + goalLen.ToString("F1") + "m";
    }

    void Update() {
        // CameraManagerスクリプトからオブジェクトを取得
        CameraManager cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        // カメラが移動したかどうかを取得
        bool hasMoved = cameraManager.getHasMoved();
        // カメラが移動した場合
        if (hasMoved) {
            goalLen -= Time.deltaTime;
            textMeshPro.text = "ゴールまであと " + goalLen.ToString("F1") + "m";
        }
    }
}
