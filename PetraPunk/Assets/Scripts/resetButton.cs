using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class resetButton : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetGyro()
    {
        Debug.Log("Reset Gyro");
        //Screen.orientation = ScreenOrientation.Landscape;
        Input.gyro.rotationRate.Set(0,0,0);
    }

}
