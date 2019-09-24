using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float Speed;

    [Header("Controller Parameters")]
    public float FlatSpeed;
    public float SlopeSpeed;
    public float FlatAcceleration;
    public float SlopeAcceleration;
    public float OffSlopeDecay;
    public float ObstacleSpeedLoss;
    public float MinSpeed;
    public float HorizontalSpeed;

    [Header("Other stuff")]


    public FloatVariable SteeringInput;


    


    RaycastHit[] collisions;

    public Transform colliderAndGraphics;


    public bool OnSlope = false;


    float input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        input = SteeringInput.Value;
        input += Input.GetAxis("Horizontal");

        Move();





        
        
        
    }



    void Move()
    {
        if (OnSlope)
        {
            if(Speed < SlopeSpeed)
            {
                Speed += SlopeAcceleration *Time.deltaTime;

                if(Speed> SlopeSpeed)
                {
                    Speed = SlopeSpeed;
                }
            }
            
        }
        else
        {
            if(Speed< FlatSpeed)
            {
                Speed += FlatAcceleration * Time.deltaTime;
                if (Speed > FlatSpeed)
                {
                    Speed = FlatSpeed;
                }

            }
            else if(Speed > FlatSpeed)
            {
                Speed -= OffSlopeDecay * Time.deltaTime;
                if (Speed < FlatSpeed)
                {
                    Speed = FlatSpeed;
                }

            }
            
        }


        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        transform.Translate(Vector3.right *input * Time.deltaTime* HorizontalSpeed);

        int layerMask = 1 << 9;
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * 100, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            colliderAndGraphics.position = hit.point + Vector3.up;


            OnSlope = hit.transform.CompareTag("Slope");

        }

    }


    public void GetHit(Vector3 direction)
    {
        direction.y = 0;
        transform.Translate(direction);

        if( Speed > MinSpeed)
        {
            Speed -= ObstacleSpeedLoss;
            if( Speed< MinSpeed)
            {
                Speed = MinSpeed;
            }

        }
    }

    public void RotatePlayer(Vector3 normal)
    {
        print("i was called");
        colliderAndGraphics.rotation = Quaternion.LookRotation(normal);
    }

    
}
