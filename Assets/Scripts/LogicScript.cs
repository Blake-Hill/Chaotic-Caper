using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;
using Febucci.UI;
using JetBrains.Annotations;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text starsCount;
    public GameObject score;
    public GameObject highscore;
    public GameObject highscoreText;
    public GameObject GameOver;
    public int stars;
    public bool newHighScore = false;
    
   
    
    
    public void addScore(int pointsToAdd) {

        playerScore += pointsToAdd;
        score.GetComponent<TextMeshProUGUI>().SetText(playerScore.ToString()); 

    }

    

    public void addStar(int starsToAdd) {

        stars += starsToAdd;
        starsCount.text = stars.ToString();
        PlayerPrefs.SetInt("currentStars", stars);
        Debug.Log("Star Collected");
        
    }

    
    public void restartGame() {

        SceneManager.LoadScene("SampleScene");
    
    }

    public void gameOver() {
        Vector3 vect = new Vector3();
           
        CheckHighScore();
        if (PlayerPrefs.GetInt("highScore") > 999)
        {
            vect.Set(550,345,0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;
            /*highscoreText.GetComponent<RectTransform>().position.Set(550, 345, 0);*/
        }
        else if (PlayerPrefs.GetInt("highScore") > 99)
        {
            vect.Set(595, 345, 0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;
/*            highscoreText.GetComponent<RectTransform>().position.Set(595, 345, 0);*/
        }
        else if (PlayerPrefs.GetInt("highScore") > 9) 
        {
            vect.Set(640, 345, 0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;
            /*highscoreText.GetComponent<RectTransform>().position.Set(640, 345, 0);*/
        }
        else
        {
            vect.Set(695, 345, 0);
            highscoreText.GetComponent<RectTransform>().localPosition = vect;
            /*highscoreText.GetComponent<RectTransform>().rect.Set(695, 345, 500, 325);
            highscoreText.GetComponent<RectTransform>().position.Set(695, 345, 0);*/
        }
        string highScore = PlayerPrefs.GetInt("highScore").ToString();
        if (newHighScore)
        {
            highscoreText.GetComponent<TextAnimator>().SetText("<rainb>HIGH</rainb>", false);
            highscore.GetComponent<TextAnimator>().SetText("<rainb>" + highScore + "</rainb>", false);
        }
        else 
        {
            highscore.GetComponent<TextAnimator>().SetText(highScore, false);
        }

        
        PlayerPrefs.SetInt("totalStars", PlayerPrefs.GetInt("totalStars") + PlayerPrefs.GetInt("currentStars"));
        PlayerPrefs.SetInt("currentStars", 0);
        starsCount.text = PlayerPrefs.GetInt("totalStars").ToString();

        GameOver.SetActive(true);
        Debug.Log("Gameover");
    }

    public void CheckHighScore() {

        if (playerScore > PlayerPrefs.GetInt("highScore"))
        {

            PlayerPrefs.SetInt("highScore", playerScore);
            newHighScore = true;

        }

    }
    



    

    
}
