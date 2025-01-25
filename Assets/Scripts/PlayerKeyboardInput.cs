using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKeyboardInput : MonoBehaviour {
    // 大ジャンプかどうか判定するために使用
    private float nowJumpTime = 0.0f;

    // Playerが移動・ジャンプするためのインスタンス作成
    [SerializeField] private GameObject Player;
    private PlayerJump playerJump;
    private PlayerMove playerMove;

    void Start() {
        playerJump = Player.GetComponent<PlayerJump>();
        playerMove = Player.GetComponent<PlayerMove>();
    }

    void Update() {
        // 現在のキーボード情報
        var current = Keyboard.current;

        // キーボード接続チェック
        if (current == null) {
            return;
        }

        // ジャンプに対応するキー
        var spaceKey = current.spaceKey;
        var upArrowKey = current.upArrowKey;
        var wKey = current.wKey;
        // 左移動に対応するキー
        var leftArrowKey = current.leftArrowKey;
        var aKey = current.aKey;
        // 右移動に対応するキー
        var rightArrowKey = current.rightArrowKey;
        var dKey = current.dKey;

        // 左に移動
        if (leftArrowKey.wasPressedThisFrame || aKey.wasPressedThisFrame) {
            playerMove.MoveLeft();
        }
        // 右に移動
        else if (rightArrowKey.wasPressedThisFrame || dKey.wasPressedThisFrame) {
            playerMove.MoveRight();
        }
        // ジャンプボタンが押された
        else if (spaceKey.wasPressedThisFrame || upArrowKey.wasPressedThisFrame || wKey.wasPressedThisFrame) {
            nowJumpTime = 0.0f;
        }
        // ジャンプボタンが押され続けている
        else if (!playerJump.isJumping && (spaceKey.isPressed || upArrowKey.isPressed || wKey.isPressed)) {
            nowJumpTime += Time.deltaTime;
            Debug.Log("pressed: " + nowJumpTime);
        }
        // ジャンプボタンから指が離れた
        else if (!playerJump.isJumping && (spaceKey.wasReleasedThisFrame || upArrowKey.wasReleasedThisFrame || wKey.wasReleasedThisFrame)) {
            Debug.Log(nowJumpTime);
            if (nowJumpTime >= playerJump.getLongJumpTime()) {
                playerJump.Jump(PlayerJump.JumpKinds.Long);
                playerJump.isJumping = true;
                nowJumpTime = 0.0f;
            } else {
                playerJump.Jump(PlayerJump.JumpKinds.Normal);
                playerJump.isJumping = true;
                nowJumpTime = 0.0f;
            }
        }
    }
}