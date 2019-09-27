using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioBankVariable : ScriptableObject 
{
    public AK.Wwise.Bank SoundBank;

    void OnEnable() {
        SoundBank.Load();
    }

    void OnDisable() {
        SoundBank.Unload();
    }
}
