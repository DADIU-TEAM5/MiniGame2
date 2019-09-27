using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialController : MonoBehaviour
{

    public GameObject player;
    public GameObject phoneUI;
    public Text dashText;

    public Animator animator;



    // Use Enum or int instead
    private bool isTurningRight=true;
    private bool isTurningLeft=false;
    private bool isDashing = false;
    private bool isJumping = false;
    private bool isFinal = false;
    private int dashCount;

    public float animationSpeed;
    public float maxTurn;
    public float dodgeTime = 10;

    public GameObject[] tutorialSegments;
    public LevelSegment nextSegment;

    private void Awake()
    {
        dashText.enabled = false;
        nextSegment.Segment = tutorialSegments[0];
    }

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

        // Part 3 - start dodging pipes
        if (player.transform.position.x < -maxTurn && isTurningLeft)
        {
            Debug.Log("position: " + player.transform.position.x);
            isTurningLeft = false;
            Destroy(phoneUI);
            nextSegment.Segment = tutorialSegments[2];
            StartCoroutine(timeToDodge());
        }

        // Part 4 - Start Dashing
        if (isDashing)
        {
            Debug.Log("We Dashin");
            if (!dashText.enabled)
            {
                dashCount = 0;
                Debug.Log("Dash Text On");
                dashText.enabled = true;
            }

            if (dashCount >= 3)
            {
                Debug.Log("Tutorial is Done");
                dashText.enabled = false;
                isDashing = false;
                isJumping = true;

            }

        }

        // Part 5 - Start Jumping
        if (isJumping)
        {
            Debug.Log("We Jumping");
            isFinal = true;
        }

        // Part Final
        if (isFinal)
        {
            Debug.Log("Final part initiated");
        }

    }

    IEnumerator timeToDodge()
    {
        print(Time.time);
        yield return new WaitForSeconds(dodgeTime);
        print(Time.time);
        isDashing = true;
    }

    public void IncreaseDashCount()
    {
        dashCount++;
        Debug.Log("Dash Count: " + dashCount);
    }

}
