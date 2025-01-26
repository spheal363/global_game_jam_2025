using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextChange : MonoBehaviour
{
    private Text textMeshPro;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private float goalLen = 500.0f;
    [SerializeField] private float goalTriggerValue = 10f;
    [SerializeField] private BackgroundScroller backgroundScroller;
    [SerializeField] private GameObject kobitoHouse;
    [SerializeField] private Vector3 houseTargetTrans;
    [SerializeField] private float moveDuration;
    void Start() {
        textMeshPro = GetComponent<Text>();
        textMeshPro.text = "ゴールまであと" + goalLen.ToString("F1") + "m";
    }

    void Update() {
        if (goalLen <= 0 || gameOver.isGameOver) return;
        // CameraManagerスクリプトからオブジェクトを取得
        CameraManager cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        // カメラが移動したかどうかを取得
        bool hasMoved = cameraManager.getHasMoved();
        // カメラが移動した場合
        if (hasMoved) {
            goalLen -= Time.deltaTime;
            textMeshPro.text = "ゴールまであと" + goalLen.ToString("F1") + "m";
        }

        if (goalLen <= goalTriggerValue)
        {
            // 背景スクロールを止める
            backgroundScroller.isShowGoal = true;
            Debug.Log("小人の家をだす");
            kobitoHouse.SetActive(true);
            kobitoHouse.transform.DOMove(houseTargetTrans, moveDuration);
        }

    }
}
