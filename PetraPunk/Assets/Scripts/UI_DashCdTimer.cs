    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DashCdTimer : MonoBehaviour
{
    public FloatVariable DashCDTimer;
    public Text UIText;
    public BoolVariable dashCooldownActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DashCDTimer.Value > 0f) {
            UIText.enabled = true;
            UIText.text = "Dash Cooldown";
        } else {
            UIText.enabled = false;
        }
    }
}
