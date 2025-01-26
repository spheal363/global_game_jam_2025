using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Bubble : MonoBehaviour
{
    public float blinkInterval = 0.2f; // 点滅の間隔
    public int blinkCount = 5; // 点滅の回数

    private Rigidbody2D rb;
    private Animator animator;
    public SpriteRenderer sprite;
    public float minLifeTime;
    public float maxLifeTime;
    public float minAddForceX; // 生成時に加える最小のX方向の力
    public float maxAddForceX; // 生成時に加える最大のX方向の力
    public float minGravity;
    public float maxGravity;
    public float rotationForce = 10;


    private void Start()
    {
        // Rigidbody2Dの取得
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.LogWarning($"{gameObject.name}にRigidbody2Dがアタッチされていません。アタッチしてください。");
        }

        AddInitialForce();
        Initialize();
        StartCoroutine(DisappearAfterTime());

        int random = Random.Range(0, 2);
        if (random == 0)
        {
            rotationForce -= rotationForce * 2;
        }
    }
    private void Update() {
        SelfRotation();
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
            // 透明度を0にフェードアウト
            sprite.DOFade(0, blinkInterval / 2).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(blinkInterval / 2);

            // 透明度を1にフェードイン
            sprite.DOFade(1, blinkInterval / 2).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(blinkInterval / 2);
        }

        // 最後にオブジェクトを破棄
        Pop();
    }
    private void SelfRotation()
    {
        // 自身をY軸を中心に回転させる
        Debug.Log("回転");
        transform.Rotate(0, 0, rotationForce * Time.deltaTime);
    }
    public void Pop()
    {
        animator.SetTrigger("Pop");
        Destroy(gameObject, 0.5f);
    }
}
