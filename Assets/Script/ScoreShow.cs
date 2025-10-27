using TMPro;
using UnityEngine;

public class ScoreShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            tM.text = "This Charrenge Score:" +
                ScoreManager.Instance.GetScore().ToString();

            ScoreManager.Instance.ResetScore();
        }
    }
}
