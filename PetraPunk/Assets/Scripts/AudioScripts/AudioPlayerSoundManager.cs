using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerSoundManager : MonoBehaviour
{
    public AK.Wwise.Event Dash;
    public AK.Wwise.Event Uncool;



    void Start()
    {
        
    }

    void Update()
    {
  
    }


    public void AudioDash()
    {
        Dash.Post(this.gameObject);
    }

    public void UnCool()
    {
        Uncool.Post(this.gameObject);
    }
}
