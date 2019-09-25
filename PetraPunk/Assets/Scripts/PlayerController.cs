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


    public float DashLength = 2;
    public float DashCD = 1;
    public float DashDuration = 0.5f;

    [Header("Other stuff")]

    float dashCDtimer;
    float dashTime;
    Vector3 dashStartPos;
    bool isDashing;
    float dashDirection;

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

        if (!isDashing)
        {
            input = SteeringInput.Value;
            input += Input.GetAxis("Horizontal");
        }
        else
            input = 0;

        Move();

        if(Input.GetMouseButtonDown(0))
        {
            Dash(-1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Dash(1);
        }

        ApplyDashMovement();

        //audio setup
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
        endDash();
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


    void Dash(float direction)
    {
        if (dashCDtimer <= 0)
        {
            dashCDtimer = DashCD;

            dashDirection = DashLength * direction;
                //print("DASH!");
            dashStartPos = transform.position;
            isDashing = true;
            
        }
        else
        {
           // print("dash on CD");
        }
        
    }
    void ApplyDashMovement()
    {
        print(dashCDtimer);
        if (dashCDtimer > 0 && !isDashing)
        {
            dashCDtimer -= Time.deltaTime;

        }
        if (isDashing)
        {
            dashTime += Time.deltaTime;

            dashStartPos.z = transform.position.z;
            
            transform.position = Vector3.Lerp(dashStartPos, dashStartPos + (Vector3.right * dashDirection), dashTime / DashDuration);
            
            if(dashTime >= DashDuration)
            {
                endDash();
            }
        }
    }
    void endDash()
    {
        //print("dashEnded");
        isDashing = false;
        dashTime = 0;
        

    }
    
}
