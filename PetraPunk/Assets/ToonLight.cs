using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToonLight : MonoBehaviour
{
    private Light light = null;

    private void OnEnable() 
    {
        light = this.GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_ToonLightDirection_", -this.transform.forward);    
    }
}
