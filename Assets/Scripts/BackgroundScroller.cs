using UnityEngine;
using TMPro; // TextMeshProを使用するために必要

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f; // スクロール速度
    public float backgroundWidth = 10f; // 背景1枚の幅（画像のサイズに合わせる）
    public TextMeshProUGUI distanceText; // スクロール距離を表示するTextMeshPro
    public float distanceModifier = 1;
    private Transform[] backgrounds; // 背景のTransform配列
    private float totalScrollDistance = 0f; // 合計スクロール距離を記録

    private void Start()
    {
        // 背景オブジェクトを取得（子オブジェクトとして配置する想定）
        int childCount = transform.childCount;
        backgrounds = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        if (backgrounds.Length < 3)
        {
            Debug.LogError("背景オブジェクトが3枚以上必要です。");
        }

        if (distanceText == null)
        {
            Debug.LogError("TextMeshProUGUIをアタッチしてください。");
        }
    }

    private void Update()
    {
        // 背景をスクロール
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // 背景が画面外に出たら右端に再配置
            if (backgrounds[i].position.x <= -backgroundWidth)
            {
                float rightMostX = GetRightMostBackgroundX();
                backgrounds[i].position = new Vector3(rightMostX + backgroundWidth, backgrounds[i].position.y, backgrounds[i].position.z);
            }
        }

        // スクロール距離を加算
        totalScrollDistance += scrollSpeed * Time.deltaTime * distanceModifier;

        // スクロール距離をテキストに反映
        UpdateDistanceText();
    }

    private float GetRightMostBackgroundX()
    {
        // 一番右にある背景のX座標を取得
        float rightMostX = backgrounds[0].position.x;
        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (backgrounds[i].position.x > rightMostX)
            {
                rightMostX = backgrounds[i].position.x;
            }
        }
        return rightMostX;
    }

    private void UpdateDistanceText()
    {
        if (distanceText != null)
        {
            // 合計スクロール距離をm単位で表示
            distanceText.text = $"{totalScrollDistance:F2} m";
        }
    }
}
