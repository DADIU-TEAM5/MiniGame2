using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialJumpController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvent jump;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        jump.Raise();
    }
}
