using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int CoinScore;
    public int Score;
    public int TotalScore;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start()
    {
        Score = 0;
        CoinScore = 0;
        PlayerPrefs.SetInt("CoinScore", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("CoinCount", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void IncrementScoreDiamond()
    {
        CoinScore++;
        PlayerPrefs.SetInt("CoinCount", CoinScore);
    }

    public void IncrementScore()
    {
        Score += 1;
        PlayerPrefs.SetInt("Score", Score);
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);

    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        TotalScore = Score + (CoinScore * 4);
        PlayerPrefs.SetInt("CoinScore", CoinScore * 4);
        PlayerPrefs.SetInt("Score",Score);
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (TotalScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", TotalScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", TotalScore);
        }
    }
}
