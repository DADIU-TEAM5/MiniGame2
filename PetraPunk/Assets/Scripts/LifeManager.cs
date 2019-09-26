using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public FloatVariable Lifes;
    public Text lifeDisplay;
    public GameEvent death;
    public GameEvent deathAudio;

    public int NumberOfLifes;

    string startString;
    // Start is called before the first frame update
    void Start()
    {
        Lifes.Value = NumberOfLifes;
        startString = lifeDisplay.text;
    }

    // Update is called once per frame
    void Update()
    {

        lifeDisplay.text = startString + Lifes.Value;

        if(Lifes.Value <= 0)
        {
            print("game Over");

            death.Raise();
            deathAudio.Raise();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
