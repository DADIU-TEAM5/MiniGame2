using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GytoTilt : MonoBehaviour
{
    // Start is called before the first frame update
    public FloatVariable gyrocontroller;

    public float angle = 45;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.Rotate(transform.forward, -angle * gyrocontroller.Value);
    }
}
