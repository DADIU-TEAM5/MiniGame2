using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSegmentAudio : MonoBehaviour
{

    [System.Serializable]
    public enum AudioZones
    {
        EnterLampZone,
        ExitLampZone,
    }

    public AudioZones audioZone;

    [Header("Other")]
    public GameEvent EnterLampZone;
    public GameEvent ExitLampZone;

    void InitAudio(int audioZone)
    {
        switch (audioZone)
        {
            case 1:
                EnterLampZone.Raise();
                break;
            case 2:
                ExitLampZone.Raise();
                break;
        }
    }
}
