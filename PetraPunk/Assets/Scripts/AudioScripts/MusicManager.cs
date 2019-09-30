using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public void EnterLampZone ()
    {
        AkSoundEngine.SetRTPCValue("InCalmZone",100);
    }

    

    public void ExitLampZone()
    {
        AkSoundEngine.SetRTPCValue("InCalmZone", 0);
    }

}
