﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionInfo : MonoBehaviour
{
    public Transform PlayerTrans;
    public PlayerController playerController;
    public AudioCue audioCue;


    private void OnCollisionEnter(Collision collision)
    {
        
        
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            playerController.GetHit(collision.GetContact(0).normal);

            audioCue.Play(collision.gameObject);


        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            playerController.HitWall(collision.GetContact(0).normal.x);
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
