using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
     public float timeRemaining = 120;
     public Text timerText;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else 
        {
        	timeRemaining = 0;
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime (float time){
    	if (time < 0){
    		time = 0;
    	}

    	float minutes = Mathf.FloorToInt(time / 60);
    	float seconds = Mathf.FloorToInt(time % 60);

    	timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
