using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{


    public bool paused;
    public Button gameToggleButton;
    public Sprite play;
    public Sprite pause;
    public Text PauseText;
    public bool Flag;
    // public Animator countDown;

    public static PauseButton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        if (Flag == true)
        {

            paused = !paused;

            if (paused)
            {
                Time.timeScale = 0;
                gameToggleButton.GetComponent<Image>().sprite = play;
                PauseText.text = "PLAY";
                PlayerController.instance.Flag = 0;
            }

            else if (!paused)
            {
                gameToggleButton.GetComponent<Image>().sprite = pause;
                PauseText.text = "PAUSE";
                Time.timeScale = 1;
                PlayerController.instance.Flag = 1;

            }
        }
    }
}
