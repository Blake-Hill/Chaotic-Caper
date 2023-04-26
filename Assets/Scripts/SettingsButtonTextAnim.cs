using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

//ANIMATION LOGIC FOR THE SETTINGS BUTTON ON MAIN MENU

public class SettingsButtonTextAnim : MonoBehaviour
{
    //create a game object to hold the settings button, be sure to link it in unity! 
    public GameObject SettingsButtonText;

    //onHover method to make settingsButtonText animate when hovering
    public void onHover()
    {
        SettingsButtonText.GetComponent<TextMeshProUGUI>().SetText("<wave>SETTINGS</wave>");  
    }

    //onUnhover method to kill settingsButtonText animation when no longer hovering
    public void onUnhover() 
    {
        SettingsButtonText.GetComponent<TextAnimator>().SetText("SETTINGS", false);
    }
}
