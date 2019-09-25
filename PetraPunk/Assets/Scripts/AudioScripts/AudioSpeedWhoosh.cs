using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpeedWhoosh : MonoBehaviour
{

    public AK.Wwise.Event WhooshSound;
    public FloatVariable PlayerSpeed;
    public float SeeSpeed;

    void Start()
    {
        AkSoundEngine.PostEvent("SpeedWhoosh", gameObject);   
    }

    void Update()
    {
        AkSoundEngine.SetRTPCValue("PlayerSpeed", PlayerSpeed.Value);
        SeeSpeed = PlayerSpeed.Value;
    }

}
