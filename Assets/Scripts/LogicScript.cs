using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;
using Febucci.UI;
using JetBrains.Annotations;

//THIS SCRIPT CONTROLS ALL OF THE GAMES LOGIC

public class LogicScript : MonoBehaviour
{
    //create a game object to hold the current score, be sure to link it in unity!
    public GameObject score;
    //create a game object to hold the highscore, be sure to link it in unity!
    public GameObject highscore;
    //create a game object to hold the highscoreText, be sure to link it in unity!
    public GameObject highscoreText;
    //create a game object to hold the GameOver scene, be sure to link it in unity!
    public GameObject GameOver;

    //Scoring and Stars variables
    public int playerScore;
    public bool newHighScore = false;
    public Text starsCount;
    public int stars;
    
    //method to add score, called on collision with trigger between pipes
    public void addScore(int pointsToAdd) {
        //update score variable
        playerScore += pointsToAdd;
        //set displayed score text = to score variable
        score.GetComponent<TextMeshProUGUI>().SetText(playerScore.ToString()); 
    }

    //method to add star, called on collision with a star
    public void addStar(int starsToAdd) {
        //update current stars variable
        stars += starsToAdd;
        //set displayed stars count = to stars variable
        starsCount.text = stars.ToString();
    }

    //method to restart game, called when restart game button is pressed
    public void restartGame() {
        //load game scene
        SceneManager.LoadScene("SampleScene");
    }

    //checks if current score is greater than highscore
    //if so replace highscore with current score
    public void CheckHighScore() {
        if (playerScore > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            newHighScore = true;
        }
    }

    //game over logic, called when cat bonks or falls off stage
    public void gameOver() {
        //declare a new vector for positioning highscore text based on size of the number
        Vector3 vect = new Vector3();
        
        //check to see if new highscore is set
        CheckHighScore();
        //store the highscore as a variable to later display
        string highScore = PlayerPrefs.GetInt("highScore").ToString(); 
       

        //position highscore text based on size of score
        if (PlayerPrefs.GetInt("highScore") > 999)
        {
            vect.Set(550,345,0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;  
        }
        else if (PlayerPrefs.GetInt("highScore") > 99)
        {
            vect.Set(595, 345, 0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;
        }
        else if (PlayerPrefs.GetInt("highScore") > 9) 
        {
            vect.Set(640, 345, 0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;
        }
        else
        {
            vect.Set(695, 345, 0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;
        }

        //if new highscore is set add a rainbow effect to displayed text and num
        //else just display the old highscore   
        if (newHighScore)
        {   
            highscoreText.GetComponent<TextAnimator>().SetText("<rainb>HIGH</rainb>", false);
            highscore.GetComponent<TextAnimator>().SetText("<rainb>" + highScore + "</rainb>", false);
        }
        else 
        {
            highscore.GetComponent<TextAnimator>().SetText(highScore, false);
        }

        //add gained stars to total stars
        PlayerPrefs.SetInt("totalStars", PlayerPrefs.GetInt("totalStars") + stars);
        //reset gained stars for next run
        PlayerPrefs.SetInt("currentStars", 0);
        //replace displayed star count with total star count
        starsCount.text = PlayerPrefs.GetInt("totalStars").ToString();

        //set gameover scene to active
        GameOver.SetActive(true);
    }

    
    



    

    
}
