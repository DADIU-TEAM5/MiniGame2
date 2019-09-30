using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_UI : MonoBehaviour
{

    public AK.Wwise.Event Death;
    public AK.Wwise.Event UISelect;
    public AK.Wwise.Event UIOpen;
    public AK.Wwise.Event UIClose;
    public AK.Wwise.RTPC MusicLevelRTPC;
    public AK.Wwise.RTPC SFXLevelRTPC;
    public FloatVariable MusicLevel;
    public FloatVariable SFXLevel;


    public void OnMusicLevelChange()
    {
        MusicLevelRTPC.SetValue(this.gameObject, MusicLevel.Value);
    }

    public void OnSFXLevelChange()
    {
        SFXLevelRTPC.SetValue(this.gameObject, SFXLevel.Value);
    }

    public void PlayerDeath()
    {
        Death.Post(this.gameObject);
    }

    public void UISelectEvent()
    {
        UISelect.Post(this.gameObject);
    }

    public void UIOpenEvent()
    {
        UIOpen.Post(this.gameObject);
    }

    public void UICloseEvent()
    {
        UIClose.Post(this.gameObject);
    }


}
