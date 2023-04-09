using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public bool timerStart;
    public bool stopTimer;
    public TextMeshProUGUI clocktext;

    private float time;
    private float minutes;
    private float seconds;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        clocktext.text = "00:00";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart && !stopTimer)
        {
            time += Time.deltaTime;
            seconds = (int)(time % 60);
            minutes = (int)(time / 60) % 60;
            clocktext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (stopTimer)
        {
            timerStart = false;
        }
        
    }

    public void StartTimer()
    {
        timerStart = true;
        time = 0;
    }
}
