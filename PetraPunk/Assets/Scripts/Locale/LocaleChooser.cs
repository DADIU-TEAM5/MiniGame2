using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocaleChooser : MonoBehaviour
{
    public LocaleManager Manager;

    public Locale Locale;
    
    public void SetLocale()
    {
        Manager.SetLocale(Locale);
    }
}
