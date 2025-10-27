using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    [SerializeField] private float floatAmplitude = 0.3f; // —h‚ê‚Ì•
    [SerializeField] private float floatFrequency = 1f;   // —h‚ê‚Ì‘¬‚³

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // ‰ŠúˆÊ’u‚ğ‹L˜^
    }

    void Update()
    {
        // ã‰º‚É‚ä‚ç‚ä‚ç
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
