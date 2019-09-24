using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{
    public float steeringInput;
    public float maxVelocity;


    public FloatVariable steeringInputFloat;

    //public Text tex;


    float timer = 0;

    float rotationThreshHold = 0.2f;
    float currentRot = 0;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Input.gyro.enabled = true;
        //transform.Rotate(Vector3.up * 30);
    }

    // Update is called once per frame
    void Update()
    {
        float rotRate = Input.gyro.rotationRate.z;
        currentRot += rotRate * Time.deltaTime;

        
        float cappedRotation = 

        steeringInput = currentRot *-10f;
        Debug.Log(steeringInput);



        steeringInputFloat.Value = steeringInput;
        //transform.Rotate(Vector3.up * Mathf.Min(steeringInput * 100, maxVelocity) * Time.deltaTime);
       // transform.Translate(Vector3.left * steeringInput * 10 * Time.deltaTime);

        //if (Mathf.Abs(currentRot) > rotationThreshHold)
        //{
        //    //timer = 0;
        //    if (currentRot < 0)
        //    {
        //        steeringInput = -1;
        //    }
        //    else
        //    {

        //        steeringInput = 1;
        //    }
        //}
        //else
        //{

        //    steeringInput = 0;

        //}


    }
}
