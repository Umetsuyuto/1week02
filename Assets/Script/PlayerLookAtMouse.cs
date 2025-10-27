using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f; // ��]�̑���
    [SerializeField] private PlayerHP p;

    void Update()
    {
        if (p != null && p.IsDie())
        {
            return;
        }
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0; // Z�͖���

        // �ڕW�����x�N�g��
        Vector3 direction = mouseWorldPos - transform.position;

        // ���E��������
        float targetYRotation = direction.x < 0 ? 180f : 0f;

        // ���݂̉�]����ڕW��]�ɕ��
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = Mathf.LerpAngle(currentRotation.y, targetYRotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = currentRotation;
    }
}
