using NUnit.Framework;
using UnityEngine;

public class TimeToScore : MonoBehaviour
{
    [SerializeField] private int Score = 10;
    [SerializeField] private float ScoreGetTime = 10f;
    private float MaxTime;
    [SerializeField] AudioSource Add;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       MaxTime = ScoreGetTime;
    }
    // Update is called once per frame
    void Update()
    {
        ScoreGetTime-=Time.deltaTime;
        if (ScoreGetTime <= 0)
        {
            Add.Play();
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(Score);
            }
            ScoreGetTime = MaxTime;
        }
    }
        
}
