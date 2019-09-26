using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameEvents : MonoBehaviour
{

    public AK.Wwise.Event DeathAudio;

    void Start()
    {
        
    }

    public void DeathAudioEvent()
    {
        DeathAudio.Post(this.gameObject);
    }

    
    void Update()
    {
        
    }
}
