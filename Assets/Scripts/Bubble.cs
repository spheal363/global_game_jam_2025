using UnityEngine;
using UnityEngine.InputSystem;

public class Bubble : MonoBehaviour
{
    public float blinkInterval = 0.2f; // 点滅の間隔
    public int blinkCount = 5; // 点滅の回数

    private Rigidbody2D rb;
    public SpriteRenderer[] spriteRenderers;
    public float minLifeTime;
    public float maxLifeTime;
    public float minAddForceX; // 生成時に加える最小のX方向の力
    public float maxAddForceX; // 生成時に加える最大のX方向の力
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
        Vector2 addForce = new Vector2(Random.Range(minAddForceX, maxAddForceX), 0);
        rb.AddForce(addForce, ForceMode2D.Impulse);
    }

    private System.Collections.IEnumerator DisappearAfterTime()
    {
        float lifeTime = Random.Range(minLifeTime, maxLifeTime);
        // 指定時間待機
        yield return new WaitForSeconds(lifeTime);

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
