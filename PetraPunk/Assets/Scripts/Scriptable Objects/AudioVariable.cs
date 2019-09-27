using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioVariable : ScriptableObject
{
    public AK.Wwise.Event AudioEvent;

    public AK.Wwise.Bank Bank;

    public void PostEvent(GameObject source) {
        AudioEvent.Post(source);
    }
}
