using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionInfo : MonoBehaviour
{
    public Transform PlayerTrans;
    public PlayerController playerController;
    public AudioCue audioCue;
    public FloatVariable distanceToObstacle;

    public float radiusOfSphere = 5;

    private void Update()
    {
        float closesDistanceToObstacle = float.MaxValue;

       Collider[] closeObjects = Physics.OverlapSphere(transform.position, radiusOfSphere);
        

        //print(closeObjects.Length);

        for (int i = 0; i < closeObjects.Length; i++)
        {
            if (closeObjects[i].CompareTag("Obstacle"))
            {
               float dist = Vector3.Distance(closeObjects[i].ClosestPoint(transform.position), transform.position);

                if (dist < closesDistanceToObstacle)
                    closesDistanceToObstacle = dist;
            }
        }

        if(closesDistanceToObstacle != float.MaxValue)
        {
            distanceToObstacle.Value = 1- closesDistanceToObstacle / radiusOfSphere;
        }
        else
        {
            distanceToObstacle.Value = 0;
        }

        print(distanceToObstacle.Value);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            playerController.GetHit(collision.GetContact(0).normal);
            audioCue.Play(collision.gameObject);


        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            float xPos = collision.collider.ClosestPoint(transform.position).x;
            playerController.HitWall(collision.GetContact(0).normal.x,xPos);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            playerController.leaveWall();
        }
    }


}
