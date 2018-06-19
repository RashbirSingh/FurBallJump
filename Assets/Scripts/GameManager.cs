using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance; 
    bool gameOver;


	private void Awake()
	{
        DontDestroyOnLoad(this.gameObject);
        if(Instance == null){
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}


	// Use this for initialization
	void Start () {
        gameOver = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart(){
        ScoreManager.instance.StartScore();
        UIManager.instance.GameStart();
        GameObject.Find("CloudSpawner").GetComponent<BirdSwpawner>().StartSpwaningBirds();
        GameObject.Find("BirdSpawner").GetComponent<BirdSwpawner>().StartSpwaningBirds();
        GameObject.Find("CoinSpawner").GetComponent<BirdSwpawner>().StartSpwaningBirds();
        PauseButton.instance.Flag = true; // pause button ON when game is  started
    }

    public void GameOver(){
        
        GameObject.Find("CloudSpawner").GetComponent<BirdSwpawner>().StopSpwaningBirds();
        GameObject.Find("BirdSpawner").GetComponent<BirdSwpawner>().StopSpwaningBirds();
        GameObject.Find("CoinSpawner").GetComponent<BirdSwpawner>().StartSpwaningBirds();
        gameOver = false;
        ScoreManager.instance.StopScore();
        UIManager.instance.GameOver();
        UnityADManager.instance.ShowAd();
        PauseButton.instance.Flag = false; // pause button OFF when game is over
    }
}
