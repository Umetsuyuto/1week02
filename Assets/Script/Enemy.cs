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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        // “§–¾‰»’†‚Å‚È‚¯‚ê‚ÎƒvƒŒƒCƒ„[‚ÉŒü‚©‚Á‚ÄˆÚ“®
        if (!isFading && player != null)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }

        if (isFading)
        {
            // “§–¾‰»
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
