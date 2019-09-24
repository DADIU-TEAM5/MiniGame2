using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPointText : MonoBehaviour
{
    public IntVariable timePoints;
    private TextMesh floatTextVal;
    private Color posColor = new Color(0, 255, 0);
    private Color negColor = new Color(255, 0, 0);
    public Vector3 Offset = new Vector3(-2, 0, 0);

    private void Start()
    {
        floatTextVal = GetComponent<TextMesh>();
        floatTextVal.text = timePoints.Value.ToString();
        floatTextVal.transform.localPosition += Offset;

        if(timePoints.Value < 0)
        {
            floatTextVal.color = negColor;
        }
        else
        {
            floatTextVal.color = posColor;
        }
    }


    public void DestroyText()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

}
