using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public bool timeOut = false;
    private float totalTime;
    public string finalTime;
    public Text timeText;
    private int seconds;
    public bool start = false;
    public GameObject timeOutPanel;
    private void Start()
    {
        timeOutPanel.SetActive(false);
        resetTime();
        timeOut = false;
    }
    private void Update()
    {
        if(timeOut == true)
        {
            timeOutPanel.SetActive(true);
        }
        if (start)
        {
            totalTime -= Time.deltaTime;
            UpdateLevelTimer(totalTime);
        }
 

        if (totalTime < 0)
        {
            timeOut = true;
            totalTime = 0;
        }
        else
        {
            timeOut = false;
        }
        timeText.text = finalTime;
    }

    public void resetTime()
    {
        totalTime = 30;
    }
    public void UpdateLevelTimer(float totalSeconds)
    {
        //int minutes_ = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds_ = Mathf.RoundToInt(totalSeconds % 60f);
   
        seconds = seconds_;
        string formatedSeconds = seconds_.ToString();

     
        finalTime = seconds_.ToString("00");
        //print(minutes.ToString("00") + ":" + seconds.ToString("00"));
        //timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
      
    }
}
