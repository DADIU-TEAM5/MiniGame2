using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int RunTimeMinutes = 1;
    public IntVariable runTime;
    public IntVariable timePoints;
    public GameObject FloatingTextPrefab;

    private float fraction = 0;
    public float speed = 0.5f;
      
    // Start is called before the first frame update
    void Start()
    {
        // Transfer value to ScriptableObject and convert to milliseconds.
        runTime.Value = (RunTimeMinutes * 60 * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        // Convert the time to milliseconds integer and subtract from current value of runTime
        runTime.Value -= Mathf.FloorToInt(1000*Time.deltaTime);
    }

    public void AddSubtract(int seconds)
    {
        if (timePoints)
        {
            timePoints.Value = seconds;
            ShowFloatingText();
        }
        
        // Convert seconds to milliseconds and add to timer
        runTime.Value += seconds * 1000;
    }

    private void ShowFloatingText()
    {
        // Instantiate the points at an Object
        // THIS NEEDS TO BE ADAPTED FOR A COLLIDER ON DIFFERENT OBJECTS

        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);

        //Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
    }

}
