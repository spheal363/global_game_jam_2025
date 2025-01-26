using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController:MonoBehaviour
{
    // ボタンをインスペクタから設定するための変数
    public Button startButton;

    void Start()
    {
        // ボタンがクリックされたときにStartGameメソッドを呼び出す
        startButton.onClick.AddListener(StartGameMethod);
    }

    // ゲームを開始するメソッド
    void StartGameMethod()
    {
        // ゲーム画面のシーン名を指定してシーンをロード
        SceneManager.LoadScene("spheal_363_TestScene"); 
    }
}

