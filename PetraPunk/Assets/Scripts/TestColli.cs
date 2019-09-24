using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColli : MonoBehaviour
{
    public IntVariable timePoints;
    public int newPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        timePoints.Value = newPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Timer>().AddSubtract(timePoints.Value);
    }
}
