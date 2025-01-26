using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController:MonoBehaviour
{
    // �{�^�����C���X�y�N�^����ݒ肷�邽�߂̕ϐ�
    public Button startButton;

    void Start()
    {
        // �{�^�����N���b�N���ꂽ�Ƃ���StartGame���\�b�h���Ăяo��
        startButton.onClick.AddListener(StartGameMethod);
    }

    // �Q�[�����J�n���郁�\�b�h
    void StartGameMethod()
    {
        // �Q�[����ʂ̃V�[�������w�肵�ăV�[�������[�h
        SceneManager.LoadScene("spheal_363_TestScene"); 
    }
}

