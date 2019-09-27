using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioBankVariable))]
public class AudioBankEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var bank = (AudioBankVariable) target;

        if (GUILayout.Button("Load bank")) {
            bank.LoadBank();
        }
    }
}
