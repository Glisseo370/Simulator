using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, ITimer
{
    public static Timer Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private double curTime;


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        TimerRun();
    }

    private void OnDisable()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        curTime = 60;
    }

    public void TimerRun()
    {
        float roundTime = (float)Math.Round(curTime, 0);
        if (roundTime >= 60 && (roundTime - 60) >= 10)
        {
            timerText.text = "01" + " : " + (roundTime - 60);
            curTime -= Time.deltaTime;
        }
        else if (roundTime >= 60 && (roundTime - 60) <= 9)
        {
            timerText.text = "01" + " : " + "0" + (roundTime - 60);
            curTime -= Time.deltaTime;
        }
        else if (roundTime < 60 && roundTime >= 10)
        {
            timerText.text = "00" + " : " + roundTime;
            curTime -= Time.deltaTime;
        }
        else if(roundTime < 10 && roundTime >= 0)
        {
            timerText.text = "00" + " : " + "0" + roundTime;
            curTime -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Âñ¸");
            TimerStop();
        }
    }

    public void TimerStop()
    {
        if (curTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
