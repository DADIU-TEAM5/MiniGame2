using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public FloatVariable Score;
    public IntVariable SpecialPoints;
    public Text ScoreDisplay;
    public Text SpecialPointsDisplay;

    public float ScoreMultiplier;



    string startString;
    string startSpecialPointsString;

    float playerStart;
    // Start is called before the first frame update
    void Start()
    {

        playerStart = PlayerController.progress;
        Score.Value = 0;
        SpecialPoints.Value = 0;
        startString = ScoreDisplay.text;
        startSpecialPointsString = SpecialPointsDisplay.text;
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.Value = PlayerController.progress - playerStart;
        Score.Value *= ScoreMultiplier;
        ScoreDisplay.text = startString + (int) Score.Value;

        SpecialPointsDisplay.text = startSpecialPointsString + SpecialPoints.Value;

    }
}
