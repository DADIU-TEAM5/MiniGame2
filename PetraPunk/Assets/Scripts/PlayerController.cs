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

    public FloatVariable dashCDtimer;
    float dashTime;
    Vector3 dashStartPos;
    bool isDashing;
    float dashDirection;
    public GameEvent dashAudio;
    public GameEvent cooldownOverAudio;
    public BoolVariable dashCooldownActiveVar;

    public CameraMovement camScript;

    public FloatVariable gyroTilt;
    public FloatVariable playerSpeed;
    public BoolVariable audioSlope;

    public FloatVariable life;

    public FloatVariable SteeringInput;

    float hitCooldown;

    bool limitLeft, limitRight;

    RaycastHit[] collisions;

    public Transform colliderAndGraphics;


    public bool OnSlope = false;


    float input;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

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

        limitMovementInput();

        Move();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Dash(-1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Dash(1);
        }

        ApplyDashMovement();

        //audio setup
        audioSlope.Value = OnSlope;
        playerSpeed.Value = Speed;
        gyroTilt.Value = input;
        
        
        
    }

    void limitMovementInput()
    {
        if (limitRight  && input < 0)
        {
            input = 0;
        }
        if (limitLeft && input > 0)
        {
            input = 0;
        }
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
        if (limitLeft && direction.x > 0)
        {
            direction.x = direction.x * -1;
        }
        if (limitRight && direction.x < 0)
        {
            direction.x = direction.x * -1;
        }

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


    public void Dash(float direction)
    {
        if (limitLeft && direction > 0)
        {
            direction = 0;
        }
        if (limitRight && direction < 0)
        {
            direction = 0;
        }

        if (dashCDtimer.Value <= 0)
        {
            dashAudio.Raise();

            dashCDtimer.Value = DashCD;

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

        //print(dashCDtimer);
        if (dashCDtimer.Value > 0 && !isDashing)
        {
            dashCDtimer.Value -= Time.deltaTime;

            dashCooldownActiveVar.Value = true;
        }

        if (dashCDtimer.Value <= 0 && dashCooldownActiveVar.Value == true)
        {
            //Debug.Log("if " + dashCooldownActiveVar.Value);
            //Debug.Log("if " + dashCDtimer.Value);

            cooldownOverAudio.Raise();
            dashCooldownActiveVar.Value = false;
        } //else if(dashCDtimer.Value > 0 && dashCooldownActiveVar.Value == false)
       // {
           // Debug.Log("else " + dashCooldownActiveVar.Value);
           // Debug.Log("else " + dashCDtimer.Value);
       // }

        if (isDashing)
        {
            dashTime += Time.deltaTime;

            dashStartPos.z = transform.position.z;
            
            transform.position = Vector3.Lerp(dashStartPos, dashStartPos + (Vector3.right * dashDirection), dashTime / DashDuration);

            if (dashTime >= DashDuration)
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


    public void HitWall(float direction, float xHitPos)
    {
        endDash();

        if(direction < 0)
        {
            limitLeft = true;
        }
        if(direction > 0)
        {
            limitRight = true;
        }

        Vector3 temp = transform.position;

        temp.x = xHitPos;
        transform.position = temp;

    }
    public void leaveWall()
    {
        if (limitLeft )
            limitLeft = false;
        if (limitRight)
            limitRight = false;
    }

}
