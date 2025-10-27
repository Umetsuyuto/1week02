using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shotZone;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private PlayerHP p;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (p!=null&&p.IsDie())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            if (!state.IsName("Attack"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || shotZone == null) return;

        // �e����
        GameObject bullet = Instantiate(bulletPrefab, shotZone.position, Quaternion.identity);
        bullet.tag = "PlayerAttack";

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // �}�E�X�������v�Z
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // 2D�Ȃ̂�Z�͖���
            Vector2 direction = (mouseWorldPos - shotZone.position).normalized;

            // �����x�N�g���ɉ����� AddForce
            rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }

        // Attack�A�j���Đ�
        if (animator != null)
        {
            animator.Play("Attack", 0, 0f);
        }
    }
}
