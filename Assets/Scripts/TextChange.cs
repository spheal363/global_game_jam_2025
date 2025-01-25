using TMPro;
using UnityEngine;

public class TextChange : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    [SerializeField] private float goalLen = 500.0f;

    void Start() {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "�S�[���܂ł���"+ goalLen + "m";
    }

    void Update() {
        // CameraManager�X�N���v�g�����I�u�W�F�N�g���擾
        CameraManager cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        // �J�������ړ��������ǂ������擾
        bool hasMoved = cameraManager.getHasMoved();
        // �J�������ړ������ꍇ
        if (hasMoved) {
            goalLen-= Time.deltaTime;
            textMeshPro.text = "�S�[���܂ł���" + goalLen + "m";
        }
    }
}
