using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform PlayerGraphics;

    float elevation;
    float startElevation;
    float cameraStartposY;

    // Start is called before the first frame update
    void Start()
    {
        elevation = PlayerGraphics.position.y;
        startElevation = elevation;
        cameraStartposY = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {

        print("cam");
        Vector3 temp = transform.position;
        elevation = PlayerGraphics.position.y;

        temp.y = cameraStartposY -( startElevation - elevation);

        transform.position = temp;
    }
}
