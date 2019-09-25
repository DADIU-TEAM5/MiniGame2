using System.Collections;
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

            audioCue.Play(collision.GetContact(0).point);


        }
    }
}
