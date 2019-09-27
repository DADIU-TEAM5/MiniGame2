using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    //public SaveData saveData;
    // Start is called before the first frame update
    
    public void SaveData(SaveData data)
    {
        
        PlayerPrefs.SetInt("story_Mode_Completed", data.StoryModeCompleted);
        PlayerPrefs.Save();
    }

    public SaveData LoadData()
    {
        SaveData loadedData = new SaveData();

        print(PlayerPrefs.GetInt("story_Mode_Completed"));

        loadedData.StoryModeCompleted = PlayerPrefs.GetInt("story_Mode_Completed");
        


        return loadedData;
    }
}
