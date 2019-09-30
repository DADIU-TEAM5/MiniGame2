using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerSoundManager : MonoBehaviour
{
    public AK.Wwise.Event Dash;
    public AK.Wwise.Event Uncool;
    public AK.Wwise.Event PlaceholderRun;
    public AK.Wwise.Event JumpPad;
    public AK.Wwise.Event FootstepAudio;
    public AK.Wwise.Event Pitfall;
    public AK.Wwise.Event Collision;
    public AK.Wwise.Event Breath;


    public AK.Wwise.Event WhooshSound;
    public FloatVariable PlayerSpeed;
    public FloatVariable DistanceToPipes;
    public BoolVariable OnSlope;
    public float SeeSpeed;
    public float SeePipeDistance;
    public bool SeeOnSlope;



    void Start()
    {
        //WhooshSound.Post(this.gameObject);
        //PlaceholderRun.Post(this.gameObject);
        StartCoroutine(WaitAndThenDoSomething());
        
    }

    IEnumerator WaitAndThenDoSomething()
    {
        yield return new WaitForSeconds(0.01f);
        WhooshSound.Post(this.gameObject);
        PlaceholderRun.Post(this.gameObject);
        Breath.Post(this.gameObject);
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


    public void FootstepEvent()
    {
        FootstepAudio.Post(this.gameObject);
    }

    public void AudioDash()
    {
        Dash.Post(this.gameObject);
        
    }

    public void UnCool()
    {
        Uncool.Post(this.gameObject);
    }

    public void JumpPadEvent()
    {
        JumpPad.Post(this.gameObject);
    }

    public void PitfallEvent()
    {
        Pitfall.Post(this.gameObject);
    }

    public void PlayerCollision()
    {
        Collision.Post(this.gameObject);
    }




}
