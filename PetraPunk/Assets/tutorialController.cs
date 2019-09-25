using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialController : MonoBehaviour
{

    private bool isTurningRight=false;
    private bool isTurningLeft=true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnCollisionEnter(Collision collision)
    {
        System.Console.WriteLine("collision");
        Debug.Log("collision tag: " + collision.gameObject.tag);

        //if (collision.gameObject.CompareTag("tutorialLeft") && isTurningLeft)
        //{
        //    Debug.Log("Hit left collider");
        //}

        //else if (collision.gameObject.CompareTag("tutorialRight") && isTurningRight)
        //{
        //    Debug.Log("Hit right collider");
        //}
    }
}
