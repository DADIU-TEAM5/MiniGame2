using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUIUpdate : MonoBehaviour
{
    public IntVariable runTime;
    public BoolVariable deathVar;
    private Text timerUI;
    
    // Start is called before the first frame update
    void Start()
    {
        timerUI = GetComponent<Text>();
        deathVar.Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(deathVar.Value != true)
        {
            if (runTime.Value <= 0)
            {
                runTime.Value = 0;
                deathVar.Value = true;
                Debug.Log("DEAD");
            }

            var timeForText = TimeSpan.FromMilliseconds(runTime.Value);
            timerUI.text = string.Format("{0:00}:{1:00}:{2:000}", timeForText.Minutes, timeForText.Seconds, timeForText.Milliseconds);
        }

    }
}
