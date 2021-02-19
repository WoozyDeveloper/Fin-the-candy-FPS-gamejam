using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TImer : MonoBehaviour
{
    public AudioSource lose,door;
    private Text timer;
    private float timeRemaining = 120;
    public bool timerIsRunning = false;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timer = GetComponent<Text>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0.5)
            {
                timer.text = "Time left: " + (int)timeRemaining / 60 + " : " + (int)timeRemaining % 60;
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                door.Play();
                lose.Play();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        else
        {
            if(!lose.isPlaying)
                SceneManager.LoadScene(0);
        }
    }
}
