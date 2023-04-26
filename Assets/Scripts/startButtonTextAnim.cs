using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

//LOGIC TO MAKE START BUTTON ANIMATE WHEN HOVERING

public class startButtonTextAnim : MonoBehaviour
{   
    //create a game object to hold the startButtonText, be sure to link it in unity! 
    public GameObject StartButtonText;

    //onHover method to make StartGameButtonText animate
    public void onHover()
    {
        StartButtonText.GetComponent<TextMeshProUGUI>().SetText("<wave>BEGIN GAME</wave>");  
    }

    //onUnhover method to remove StartGameButtonText animation
    public void onUnhover() 
    {
        StartButtonText.GetComponent<TextAnimator>().SetText("BEGIN GAME", false);
    }
}
