using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_menu : MonoBehaviour
{

    public GameObject soundButton;
    private bool sound;

    private void Start()
    {
        sound = true;
    }

    public void mainMenuSelection(int screen)
    {
        switch (screen)
        {
            case 3:
                Debug.Log("Exit");
                Application.Quit();
                break;
            case 2:
                Debug.Log("Options");
                break;
            case 1:
                Debug.Log("new game");
                SceneManager.LoadScene(1);
                break;
        }
    }

    public void optionsMenuSelection(int screen)
    {
        switch (screen)
        {
            case 2:
                Debug.Log("back");
                break;
            case 1:
                Debug.Log("Sound is: " + sound);
                if(sound == true)
                {
                    soundButton.GetComponentInChildren<Text>().text = "sound is:off";
                    AudioListener.pause = true;
                } else
                {
                    soundButton.GetComponentInChildren<Text>().text = "sound is:on";
                    AudioListener.pause = false;
                }
                sound = !sound;
                break;
        }
            
    }


}
