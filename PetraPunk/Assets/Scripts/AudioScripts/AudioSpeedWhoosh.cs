using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpeedWhoosh : MonoBehaviour
{

    public AK.Wwise.Event WhooshSound;
    public FloatVariable PlayerSpeed;
    public BoolVariable OnSlope;
    public float SeeSpeed;
    public bool SeeOnSlope;

    void Start()
    {
        AkSoundEngine.PostEvent("SpeedWhoosh", gameObject);   
    }

    void Update()
    {
        AkSoundEngine.SetRTPCValue("PlayerSpeed", PlayerSpeed.Value);
        SeeSpeed = PlayerSpeed.Value;

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

}
