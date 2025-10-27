using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    [SerializeField] private float floatAmplitude = 0.3f; // �h��̕�
    [SerializeField] private float floatFrequency = 1f;   // �h��̑���

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // �����ʒu���L�^
    }

    void Update()
    {
        // �㉺�ɂ����
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
