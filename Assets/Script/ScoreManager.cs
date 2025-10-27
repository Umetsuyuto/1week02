using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

   
    private int score = 0;
    private int HighScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // シーン切り替え時に消さない
        DontDestroyOnLoad(gameObject);
    }


    public void AddScore(int amount)
    {
        score += amount;

    }

    public void ResetScore()
    {
        //ついでにハイスコア更新
        if (score > HighScore)
        {
            HighScore = score;
        }
        score = 0;
    }

  
    public int GetScore()
    {
        return score;
    }
    public int GetHighScore()
    {
        return HighScore;
    }
}
