using UnityEngine;

public class UIObjectFollower : MonoBehaviour {
    [SerializeField] private Transform target; // ワールド空間のターゲットオブジェクト
    [SerializeField] private RectTransform uiElement; // UI要素
    [SerializeField] private Canvas canvas; // 対象のCanvas（Screen Space - Overlayのもの）

    void Update() {
        if (target == null || uiElement == null) return;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);

        // オブジェクトがカメラの前方にあるか確認
        if (screenPosition.z > 0) {
            uiElement.position = screenPosition;
            uiElement.gameObject.SetActive(true);
        } else {
            uiElement.gameObject.SetActive(false);
        }
    }

}