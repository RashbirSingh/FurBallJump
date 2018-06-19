using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public AudioSource LoseSound; // lose, fall

    public static UIManager instance;
    public Text ScoreText;
    public Text ScoreTextGameOver; // Score Text when game over showing current score
    public Text ScoreTextCoinScore; // Score Text when game over showing coin score
    public Text ScoreTextTotalScore; // Score Text when game over showing total score
    public Text ScoreTextHighScore; //Score Text when game over showing high score
    public GameObject GameOverPanel; // when game ends
    public GameObject GameStartPanel; // when game starts
    public Text CoinText; //coin text while playing

	private void Awake()
	{
        if(instance == null){
            instance = this;
        }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "SCORE: " + PlayerPrefs.GetInt("Score");
        CoinText.text = "X " + PlayerPrefs.GetInt("CoinCount");

	}

    public void GameStart(){
        GameStartPanel.SetActive(false);

    }

    public void GameOver(){
        GameOverPanel.SetActive(true);
        ScoreTextCoinScore.text = PlayerPrefs.GetInt("CoinScore").ToString();
        ScoreTextHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        ScoreTextGameOver.text = PlayerPrefs.GetInt("Score").ToString();
        ScoreTextTotalScore.text = PlayerPrefs.GetInt("TotalScore").ToString();
        LoseSound.Play();
    }

    public void Replay(){
        SceneManager.LoadScene("Level1");
    }

    public void Home(){
        SceneManager.LoadScene("Menu");
    }


}
