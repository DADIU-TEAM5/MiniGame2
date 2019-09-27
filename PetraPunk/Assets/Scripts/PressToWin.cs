using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressToWin : MonoBehaviour
{

    public Text youWonText;

    public SaveLoadManager saveLoadManager;

    SaveData saveData;


    private void Start()
    {
        saveData = saveLoadManager.LoadData();
        

    }
    private void Update()
    {
        if (saveData.StoryModeCompleted ==1)
        {

            youWonText.text = "You Won";
        }
    }


    public void Win()
    {
        saveData.StoryModeCompleted = 1;
        
        saveLoadManager.SaveData(saveData);
    }

}
