using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class SettingsButtonTextAnim : MonoBehaviour
{
    public GameObject SettingsButtonText;

    
    //onHover method to make StartGameButtonText animate
    public void onHover()
    {
        SettingsButtonText.GetComponent<TextMeshProUGUI>().SetText("<wave>SETTINGS</wave>");  
    }

    //onUnhover method to kill StartGameButtonText animation
    public void onUnhover() 
    {
        SettingsButtonText.GetComponent<TextAnimator>().SetText("SETTINGS", false);
    }
}
