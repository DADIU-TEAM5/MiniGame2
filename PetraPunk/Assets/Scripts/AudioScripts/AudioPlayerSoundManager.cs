using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerSoundManager : MonoBehaviour
{
    public AK.Wwise.Event Dash;
    public AK.Wwise.Event Uncool;
    public AK.Wwise.Event PlaceholderRun;

    public AK.Wwise.Event WhooshSound;
    public FloatVariable PlayerSpeed;
    public FloatVariable DistanceToPipes;
    public BoolVariable OnSlope;
    public float SeeSpeed;
    public float SeePipeDistance;
    public bool SeeOnSlope;



    void Start()
    {
        WhooshSound.Post(this.gameObject);
        PlaceholderRun.Post(this.gameObject);
    }

    void Update()
    {
        AkSoundEngine.SetRTPCValue("PlayerSpeed", PlayerSpeed.Value);
        SeeSpeed = PlayerSpeed.Value;

        AkSoundEngine.SetRTPCValue("DistanceToObstacle", DistanceToPipes.Value);
        SeePipeDistance = DistanceToPipes.Value;

        if (OnSlope.Value == true)
        {
            AkSoundEngine.SetRTPCValue("PlayerOnSlope", 1);
            SeeOnSlope = true;
        }
        else
        {
            AkSoundEngine.SetRTPCValue("PlayerOnSlope", 0);
            SeeOnSlope = false;
        }

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
