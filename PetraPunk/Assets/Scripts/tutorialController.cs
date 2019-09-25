using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialController : MonoBehaviour
{

    public GameObject player;
    public GameObject phoneUI;
    public Animator animator;


    private bool isTurningRight=true;
    private bool isTurningLeft=false;

    public float animationSpeed;
    public float maxTurn;
    

    // Start is called before the first frame update
    void Start()
    {
        animator.speed = animationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Part 1 - start turning left - Automatic
        //if(player.transform.position.x!=0 && !isTurningRight)
        //{
        //    isTurningRight = true;
        //    animator.SetBool("startTutorial", true);
        //}

        // Part 2 - start turning right
        if(player.transform.position.x > maxTurn && isTurningRight)
        {
            Debug.Log("position: " + player.transform.position.x);
            isTurningRight = false;
            isTurningLeft = true;
            animator.SetBool("turnedRight", true);
        }

        if (player.transform.position.x < -maxTurn && isTurningLeft)
        {
            Debug.Log("position: " + player.transform.position.x);
            isTurningLeft = false;
            GameObject.Destroy(phoneUI);
        }
    }

    
}
