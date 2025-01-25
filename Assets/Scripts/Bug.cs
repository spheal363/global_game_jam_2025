using UnityEngine;

public class Bug : MonoBehaviour
{
    public float moveSpeed = 2f;         // 移動速度
    public float destroyXPosition = -10f; // 削除されるX座標

    // private void Start()
    // {
    //     // 初期位置を設定 (Y軸をランダム化)
    //     float randomY = Random.Range(-spawnYRange, spawnYRange);
    //     transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
    // }

    private void Update()
    {
        // 左方向に移動
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // 一定位置を超えたら削除
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // バブルに当たったら処理を実行
        if (other.CompareTag("Bubble"))
        {
            Debug.Log("シャボン玉にあたりました");
            Bubble bubble = other.GetComponent<Bubble>();
            if (bubble != null)
            {
                bubble.Pop(); // バブルがはじける処理を呼び出す
            }
            Destroy(gameObject); // 虫を削除
        }
    }
}
