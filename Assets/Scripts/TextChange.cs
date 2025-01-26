using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {
    private TextMeshProUGUI textMeshPro;
    [SerializeField] private float goalLen = 500.0f;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "ゴールまであと" + goalLen.ToString("F1") + "m";
    }

    void Update() {
        Debug.Log("goal: " + goalLen);
        // CameraManagerスクリプトからオブジェクトを取得
        CameraManager cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        // カメラが移動したかどうかを取得
        bool hasMoved = cameraManager.getHasMoved();
        // カメラが移動した場合
        if (hasMoved) {
            goalLen -= Time.deltaTime;
            textMeshPro.text = "ゴールまであと" + goalLen.ToString("F1") + "m";
        }
    }
}
