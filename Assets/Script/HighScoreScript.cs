using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.GetHighScore() != 0)
        {
            tM.text ="HighScore:"+ScoreManager.Instance.GetHighScore().ToString();
        }
    }


}
