using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; // 生成するバブルのプレハブ
    public int bubbleCount = 10; // 一度に生成するバブルの数
    public float initSpawnDelay;
    public float spawnIntervalTime;
    private BoxCollider2D spawnArea; // スポーン範囲

    private void Start()
    {
        // スポーン範囲のBoxCollider2Dを取得
        spawnArea = GetComponent<BoxCollider2D>();
        if (spawnArea == null)
        {
            Debug.LogError($"{gameObject.name}にBoxCollider2Dがありません。アタッチしてください。");
            return;
        }

        // バブルを生成
        SpawnBubbles();
        InvokeRepeating(nameof(SpawnBubbles), initSpawnDelay, spawnIntervalTime);
    }
    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBubbles();
        }
    }

    private void SpawnBubbles()
    {
        for (int i = 0; i < bubbleCount; i++)
        {
            // 範囲内のランダムな位置を取得
            Vector2 spawnPosition = GetRandomPositionWithinBounds();

            // バブルを生成
            Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetRandomPositionWithinBounds()
    {
        // スポーン範囲の中心とサイズを取得
        Bounds bounds = spawnArea.bounds;

        // 範囲内のランダムな位置を計算
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(x, y);
    }

    // デバッグ用：スポーン範囲をSceneビューに表示
    private void OnDrawGizmos()
    {
        if (spawnArea == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
    }
}
