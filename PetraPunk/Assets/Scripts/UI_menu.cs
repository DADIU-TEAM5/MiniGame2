using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_menu : MonoBehaviour
{

    public GameObject soundButton;

    [Header("Audio")]
    public GameEvent startNewLevelAudio;
    public GameEvent buttonClickAudio;
    public GameEvent menuOpenAudio;
    public GameEvent menuCloseAudio;

    private bool sound;
    private GameEvent btClick;
    private GameEvent menuOpenClick;
    private GameEvent menuCloseClick;

    private void Start()
    {
        sound = true;

        btClick = buttonClickAudio;
        menuOpenClick = menuOpenAudio;
        menuCloseClick = menuCloseAudio;
    }

    public void mainMenuSelection(int screen)
    {
        switch (screen)
        {
            case 3:
                Debug.Log("Exit");
                btClick.Raise();
                Application.Quit();
                break;
            case 2:
                Debug.Log("Options");
                menuOpenClick.Raise();
                break;
            case 1:
                Debug.Log("new game");
                btClick.Raise();
                startNewLevelAudio.Raise();
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
                menuCloseClick.Raise();
                break;
            case 1:
                Debug.Log("Sound is: " + sound);
                btClick.Raise();
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
