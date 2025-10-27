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
        // �V�[���؂�ւ����ɏ����Ȃ�
        DontDestroyOnLoad(gameObject);
    }


    public void AddScore(int amount)
    {
        score += amount;

    }

    public void ResetScore()
    {
        //���łɃn�C�X�R�A�X�V
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
