using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    float Score;
    public Text ScoreDisplay;

    public float ScoreMultiplier;



    string startString;

    float playerStart;
    // Start is called before the first frame update
    void Start()
    {

        playerStart = PlayerController.progress;
        Score = 0;
        startString = ScoreDisplay.text;
    }

    // Update is called once per frame
    void Update()
    {
        Score = PlayerController.progress - playerStart;
        Score *= ScoreMultiplier;
        ScoreDisplay.text = startString + (int) Score;

       

    }
}
