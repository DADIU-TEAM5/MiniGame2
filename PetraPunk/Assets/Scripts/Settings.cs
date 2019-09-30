using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    
    [Header("General Settings")]
    public int timerLimitSeconds;

    [Header("ScriptableObjects Variables")]
    public IntVariable timerLimitVar;
    


    // Start is called before the first frame update
    void Start()
    {
        timerLimitVar.Value = timerLimitSeconds  * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
