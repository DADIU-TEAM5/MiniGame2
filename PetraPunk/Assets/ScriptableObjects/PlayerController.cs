using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public float SlopeSpeed;

    float currentSpeed;


    public float HorizontalSpeed;


    RaycastHit[] collisions;

    public Transform colliderAndGraphics;


    public bool OnSlope = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();





        
        
        
    }



    void Move()
    {
        if (OnSlope)
            currentSpeed = SlopeSpeed;
        else
            currentSpeed = Speed;


        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime* HorizontalSpeed);

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
    }

    public void RotatePlayer(Vector3 normal)
    {
        print("i was called");
        colliderAndGraphics.rotation = Quaternion.LookRotation(normal);
    }

    
}
