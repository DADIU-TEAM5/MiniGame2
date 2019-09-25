using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float progress;


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
    public float SlopeHorizontalSpeed;
    public float slopeMultiplier = 5;

    public float invulnerableSecs = 1;

    [Header("Other stuff")]

    public CameraMovement camScript;

    public FloatVariable gyroTilt;
    public FloatVariable playerSpeed;
    public BoolVariable audioSlope;

    public FloatVariable life;

    public FloatVariable SteeringInput;

    float hitCooldown;



    RaycastHit[] collisions;

    public Transform colliderAndGraphics;


    public bool OnSlope = false;


    float input;

    // Start is called before the first frame update
    void Start()
    {
        hitCooldown = invulnerableSecs;

        Speed = MinSpeed;
    }
    private void Awake()
    {
        progress = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {


        progress = transform.position.z;

        if (hitCooldown < invulnerableSecs)
        {
            hitCooldown += Time.deltaTime;
        }

        input = SteeringInput.Value;
        input += Input.GetAxis("Horizontal");

        Move();




        audioSlope.Value = OnSlope;
        playerSpeed.Value = Speed;
        gyroTilt.Value = input;
        
        
        
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


        

        if (OnSlope)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime* slopeMultiplier);
            transform.Translate(Vector3.right * input * Time.deltaTime * SlopeHorizontalSpeed);
        }
        else
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            transform.Translate(Vector3.right * input * Time.deltaTime * HorizontalSpeed);
        }

        int layerMask = 1 << 9;
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * 100, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            colliderAndGraphics.position = hit.point + Vector3.up;


            OnSlope = hit.transform.CompareTag("Slope");

        }
        
       // print("speed: "+Speed + " speed on slope: " + Speed * slopeMultiplier);

    }

    

    public void GetHit(Vector3 direction)
    {
        camScript.ShakeCam();
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
        if (hitCooldown >= invulnerableSecs)
        {
            life.Value--;

            hitCooldown = 0;
        }
    }

    public void RotatePlayer(Vector3 normal)
    {
        print("i was called");
        colliderAndGraphics.rotation = Quaternion.LookRotation(normal);
    }


    public float GetSpeed()
    {
        return Speed;
    }
    
}
