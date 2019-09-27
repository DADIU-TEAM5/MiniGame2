using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    public bool UseSlopeAngle;

    public Transform PlayerGraphics;
    public PlayerController playerController;

    public Transform tiltedCamera;


    public float slopeBackDistance;

    public float transitionTime =1;

    Vector3 flatGoalPoistion, slopeGoalPoistionRight, slopeGoalPoistionLeft;
    Quaternion flatGoalRotation, slopeGoalRotationRight, slopeGoalRotationLeft;


    public float ShakeMaxAngle = 45;
    public float ShakeSpeed;
    public float ShakeTime;


    float shakeDuration;

    float timeOnSlope ;

    bool lastSlopeCheck;

    bool deathCam;
    Vector3 deathCamPosition, deathCamStartPosition;
    Quaternion deathCamRotation, DeathCameStartRotation;
    float deathCamLerp;

    // Start is called before the first frame update
    void Start()
    {
        shakeDuration = ShakeTime * ShakeSpeed;
        
        flatGoalPoistion =  transform.position - PlayerGraphics.position;
        slopeGoalPoistionRight = tiltedCamera.position - PlayerGraphics.position;

        slopeGoalPoistionLeft = slopeGoalPoistionRight;

        slopeGoalPoistionLeft.x = slopeGoalPoistionLeft.x * -1;


        flatGoalRotation = transform.rotation;
        slopeGoalRotationRight = tiltedCamera.rotation;

        slopeGoalRotationLeft = slopeGoalRotationRight;

        slopeGoalRotationLeft.y = slopeGoalRotationLeft.y * -1;
        slopeGoalRotationLeft.z = slopeGoalRotationLeft.z * -1;


        

    }

    // Update is called once per frame
    void Update()
    {
        if (!deathCam)
        {
            MoveCamera();


            ShakeScreen();
        }
        else
        {
            deathCamLerp += Time.deltaTime;
            transform.position = Vector3.Lerp(deathCamStartPosition, deathCamPosition, deathCamLerp);
            transform.rotation = Quaternion.Lerp(DeathCameStartRotation, deathCamRotation, deathCamLerp);
            
        }
        

    }
    void MoveCamera()
    {
        if (UseSlopeAngle)
        {
            if (playerController.transform.position.x > 0)
            {
                transform.position = Vector3.Lerp(PlayerGraphics.position + flatGoalPoistion, PlayerGraphics.position + slopeGoalPoistionRight + Vector3.back * slopeBackDistance, timeOnSlope);


                transform.rotation = Quaternion.Lerp(flatGoalRotation, slopeGoalRotationRight, timeOnSlope);
            }
            else
            {
                transform.position = Vector3.Lerp(PlayerGraphics.position + flatGoalPoistion, PlayerGraphics.position + slopeGoalPoistionLeft + Vector3.back * slopeBackDistance, timeOnSlope);


                transform.rotation = Quaternion.Lerp(flatGoalRotation, slopeGoalRotationLeft, timeOnSlope);

            }


        }
        else
        {
            transform.position = Vector3.Lerp(PlayerGraphics.position + flatGoalPoistion, PlayerGraphics.position + flatGoalPoistion + Vector3.back * slopeBackDistance, timeOnSlope);
            transform.rotation = flatGoalRotation;
        }


        if (playerController.OnSlope)
        {
            timeOnSlope += Time.deltaTime * transitionTime;
            if (timeOnSlope >= 1)
                timeOnSlope = 1;
        }
        else
        {
            timeOnSlope -= Time.deltaTime * transitionTime;
            if (timeOnSlope <= 0)
                timeOnSlope = 0;
        }
    }

    


     void ShakeScreen()
    {
        if (shakeDuration < ShakeTime * ShakeSpeed)
        {
            shakeDuration += Time.deltaTime * ShakeSpeed;

            transform.Rotate(transform.forward, Mathf.Sin(shakeDuration) * ShakeMaxAngle);
        }


        
    }

    public void ShakeCam()
    {
        shakeDuration = 0;
    }

    public void MoveToDeathCam(Transform dethCam)
    {
        deathCamPosition = dethCam.position;
        deathCamRotation = dethCam.rotation;
        deathCamStartPosition = transform.position;
        DeathCameStartRotation = transform.rotation;

        deathCam = true;


    }

}

