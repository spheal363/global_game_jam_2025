using UnityEngine;

public class UIObjectFollower : MonoBehaviour {
    [SerializeField] private Transform target; // ���[���h��Ԃ̃^�[�Q�b�g�I�u�W�F�N�g
    [SerializeField] private RectTransform uiElement; // UI�v�f
    [SerializeField] private Canvas canvas; // �Ώۂ�Canvas�iScreen Space - Overlay�̂��́j

    void Update() {
        if (target == null || uiElement == null) return;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);

        // �I�u�W�F�N�g���J�����̑O���ɂ��邩�m�F
        if (screenPosition.z > 0) {
            uiElement.position = screenPosition;
            uiElement.gameObject.SetActive(true);
        } else {
            uiElement.gameObject.SetActive(false);
        }
    }

}