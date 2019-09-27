using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioBankVariable : ScriptableObject 
{
    public AK.Wwise.Bank SoundBank;

    void OnEnable() {
        LoadBank();
    }

    public void LoadBank() {
        Debug.Log($"Loaded {SoundBank?.Name ?? "no bank"}");
        SoundBank.Load();
    }

    void OnDisable() {
        SoundBank.Unload();
    }
}
