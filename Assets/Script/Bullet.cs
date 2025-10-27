using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        // ƒJƒƒ‰ŠO‚Éo‚½‚çíœ
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }
}

