using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerCollision : MonoBehaviour
{

    public PlayerController PlayerCont;
    public AudioCue HitCue;

    void Start()
    {
        
    }

    public void CollisionPlaySound()
    {
        AkSoundEngine.PostEvent("PipeHit", gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
