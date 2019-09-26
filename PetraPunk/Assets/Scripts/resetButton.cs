using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class resetButton : MonoBehaviour
{
    public GameObject myObject;
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetGyro()
    {
        //Screen.orientation = ScreenOrientation.Landscape;
        //Input.gyro.rotationRate.Set(0,0,0);
        try
        {
            myObject.GetComponent<GyroController>().calibrateGyro();
        }
        catch(System.Exception e)
        {
            Debug.LogError("GyroController not found");
        }

        
    }

}
