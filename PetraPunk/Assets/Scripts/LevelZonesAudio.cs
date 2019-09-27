using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelZonesAudio : MonoBehaviour
{

    [Header("Select Level Zone:")]
    public int SelectedAudioZone;

    [Header("Level Zones Audio Events")]
    public GameEvent[] audioZones;


    void InitAudio()
    {

        audioZones[SelectedAudioZone].Raise();

    }
}
