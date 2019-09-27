using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventVariable : ScriptableObject
{
    public AK.Wwise.Event AudioEvent;

    public void Post(GameObject source) {
        AudioEvent.Post(source);
    }
}
