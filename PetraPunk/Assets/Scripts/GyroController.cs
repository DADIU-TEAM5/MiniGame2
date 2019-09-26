using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{

    private float gyroInput;
    public float speedMultiplier = 2;
    public float maxVelocity = 1;


    public enum control { New, Old };

    public control controlType;


    public FloatVariable steeringOutput;
    private Vector3 gyroOffset;

    float currentRot = 0;



    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Input.gyro.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        float rotRate = 0;

        if (controlType == control.Old)
        {
            //rotRate = -Input.gyro.rotationRate.y;
            rotRate = -Input.gyro.rotationRateUnbiased.y;
        }
        else
        {
            // Drift
            //rotRate = Input.gyro.rotationRate.z;

            // Drift
            rotRate = Input.gyro.rotationRateUnbiased.z - gyroOffset.z;

           // rotRate = Input.gyro.attitude.eulerAngles.z;

        }

        // Add speed multiplier to input
        currentRot += rotRate * Time.deltaTime;
        gyroInput = currentRot * -speedMultiplier;


        //Set speed cap
        if (gyroInput > 0)
        {
            steeringOutput.Value = Mathf.Min(gyroInput, maxVelocity);
        }
        else
        {
            steeringOutput.Value = Mathf.Max(gyroInput, -maxVelocity);
        }


    }

    public void calibrateGyro()
    {
        gyroOffset = Input.gyro.rotationRateUnbiased;
    }

}
