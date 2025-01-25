using UnityEngine;
using UnityEngine.InputSystem;

public class Bubble : MonoBehaviour
{
    public Vector2 addForce; // 初期の力
    public float lifetime = 3f; // バブルが消えるまでの時間
    public float blinkInterval = 0.2f; // 点滅の間隔
    public int blinkCount = 5; // 点滅の回数

    private Rigidbody2D rb;
    public SpriteRenderer[] spriteRenderers;
    public float minGravity;
    public float maxGravity;

    private void Start()
    {
        // Rigidbody2Dの取得
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning($"{gameObject.name}にRigidbody2Dがアタッチされていません。アタッチしてください。");
        }

        AddInitialForce();
        Initialize();
        StartCoroutine(DisappearAfterTime());
    }
    private void Initialize()
    {
        float gravity = Random.Range(minGravity, maxGravity);
        rb.gravityScale = gravity;
    }
    private void AddInitialForce()
    {
        rb.AddForce(addForce, ForceMode2D.Impulse);
    }

    private System.Collections.IEnumerator DisappearAfterTime()
    {
        // 指定時間待機
        yield return new WaitForSeconds(lifetime);

        // 点滅開始
        for (int i = 0; i < blinkCount; i++)
        {
            // Spriteの表示・非表示を切り替える
            foreach(SpriteRenderer sprite in spriteRenderers)
            {
                sprite.enabled = !sprite.enabled;
            }

            // 点滅間隔の待機
            yield return new WaitForSeconds(blinkInterval);
        }

        // 最後にオブジェクトを破棄
        Destroy(gameObject);
    }
}
