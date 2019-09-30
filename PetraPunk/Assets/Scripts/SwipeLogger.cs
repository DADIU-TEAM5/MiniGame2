using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeLogger : MonoBehaviour
{

    public Text SwipeText;

    public IntVariable swipe4Dash;
    private int swipeDirection;

    private void Awake()
    {
        SwipeDetection.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);

        if (data.Direction.ToString() == "Left")
        {
            swipeDirection = -1;
            swipe4Dash.Value = swipeDirection;

            SwipeText.text = "Swipe in Direction: " + swipe4Dash.Value;
        }

        if (data.Direction.ToString() == "Right")
        {
            swipeDirection = 1;
            swipe4Dash.Value = swipeDirection;

            SwipeText.text = "Swipe in Direction: " + swipe4Dash.Value;
        }



    }
}
