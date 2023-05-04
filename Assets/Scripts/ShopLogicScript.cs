using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLogicScript : MonoBehaviour
{
    //create a game object to hold the current score, be sure to link it in unity!
    public PipeSpawner pipeSpawner;
    
    //called once when game starts
    void onStart(){

        

    }
    


    public void buyBluePipe(){

        pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<PipeSpawner>();
        
        PlayerPrefs.SetInt("BluePipePrice", 10);

        if(PlayerPrefs.GetInt("totalStars") >= PlayerPrefs.GetInt("BluePipePrice")){
            PlayerPrefs.SetString("bluePipePurchased", "True");
            PlayerPrefs.SetString("equippedPipeColor", "Blue");
            pipeSpawner.pipeColor = "Blue";
        }



    }

    
}
