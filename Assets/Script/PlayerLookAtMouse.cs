using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f; // 回転の速さ
    [SerializeField] private PlayerHP p;

    void Update()
    {
        if (p != null && p.IsDie())
        {
            return;
        }
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0; // Zは無視

        // 目標方向ベクトル
        Vector3 direction = mouseWorldPos - transform.position;

        // 左右向き判定
        float targetYRotation = direction.x < 0 ? 180f : 0f;

        // 現在の回転から目標回転に補間
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = Mathf.LerpAngle(currentRotation.y, targetYRotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = currentRotation;
    }
}
