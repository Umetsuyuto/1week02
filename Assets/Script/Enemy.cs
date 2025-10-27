using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float fadeSpeed = 2f;

    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Collider2D myCollider;
    private bool isFading = false;
    public bool hitPlayer = false;
    public bool hitAttack = false;
    [SerializeField] private AudioClip enemyDeadSE;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void PlayDeathSE()//死亡SE準備
    {
        if (enemyDeadSE == null) return;

        GameObject obj = new GameObject("EnemySE");
        AudioSource src = obj.AddComponent<AudioSource>();
        src.clip = enemyDeadSE;
        src.volume = 0.6f;
        src.spatialBlend = 0f;  // ★ 2D化（距離減衰なし）
        src.Play();
        Destroy(obj, enemyDeadSE.length);
    }
    void Update()
    {
        // 透明化中でなければプレイヤーに向かって移動
        if (!isFading && player != null)
        {

            Vector3 dir = (player.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }

        if (isFading)
        {
            // 透明化
            Color c = spriteRenderer.color;
            c.a -= fadeSpeed * Time.deltaTime;
            spriteRenderer.color = c;

            if (c.a <= 0f)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isFading) return;

        if (other.CompareTag("Player"))
        {
            hitPlayer = true;
            StartFade();
        }
        else if (other.CompareTag("PlayerAttack"))
        {
            hitAttack = true;
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(50);
            }
            PlayDeathSE();
            StartFade();
        }
    }

    private void StartFade()
    {
        isFading = true;
        if (myCollider != null)
            myCollider.enabled = false;
    }
}
