using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class startButtonTextAnim : MonoBehaviour
{
    public GameObject StartButtonText;

    
    //onHover method to make StartGameButtonText animate
    public void onHover()
    {
        StartButtonText.GetComponent<TextMeshProUGUI>().SetText("<wave>BEGIN GAME</wave>");  
    }

    //onUnhover method to kill StartGameButtonText animation
    public void onUnhover() 
    {
        StartButtonText.GetComponent<TextAnimator>().SetText("BEGIN GAME", false);
    }
}
