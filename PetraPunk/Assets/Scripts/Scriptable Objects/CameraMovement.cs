﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform PlayerGraphics;
    public PlayerController playerController;

    public Transform tiltedCamera;


    public float slopeBackDistance;

    public float transitionTime =1;

    Vector3 flatGoalPoistion, slopeGoalPoistionRight, slopeGoalPoistionLeft;
    Quaternion flatGoalRotation, slopeGoalRotationRight, slopeGoalRotationLeft;




    

    float timeOnSlope ;

    bool lastSlopeCheck;


    // Start is called before the first frame update
    void Start()
    {
        
        
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

    /*
    if (timer < transitionTime)
        timer += Time.deltaTime;



    if(lastSlopeCheck != playerController.OnSlope)
    {
        timer = 0;
        lerpPoint = transform.position;
    }

    if (playerController.OnSlope)
    {
        transform.position = Vector3.Lerp(lerpPoint, PlayerGraphics.position + flatGoalPoistion +Vector3.back, timer / transitionTime);
    }
    else
    {
        transform.position = Vector3.Lerp(lerpPoint, PlayerGraphics.position + flatGoalPoistion, timer / transitionTime);
    }

    print(timer);

    lastSlopeCheck = playerController.OnSlope;

*/

}

