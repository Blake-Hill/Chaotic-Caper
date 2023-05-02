using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LOGIC SCRIPT TO SPAWN STARS

public class StarSpawnerScript : MonoBehaviour
{

    //create a game object to hold the star prefabs, be sure to link it in unity! 
    public GameObject purpleStar;
    public GameObject greenStar;
    public GameObject blueStar;

    //star moving logic variables
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 8;

    //random star color logic variables
    public string starColor;
    public float purpleStarOdds = .80f;
    public float greenStarOdds = .15f;
    public float blueStarOdds = .05f;

    //start is called before the first frame update
    void Start()
    {
        spawnStar("Green");
    }

    //update is called once per frame
    void Update()
    {
        

        //star spawning timer logic
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //create a new random number to determine the type of star to spawn
            float rand = Random.Range(0.0f, 1.0f);
            
            //      <= .8
            if(rand <= purpleStarOdds)
            {
                spawnStar("Purple");
            }//          >.8                        <=.80 + .15 = <=.95
            else if((rand > purpleStarOdds) && (rand <= purpleStarOdds + greenStarOdds))
            {
                spawnStar("Green");
            }//          > 1.0-.05 = > .95
            else if(rand > 1.0 - blueStarOdds)
            {
                spawnStar("Blue");
            }

            timer = 0;
        }
    }

    //spawn star method
    public void spawnStar(string starColor) {

        
        //create a maximum and minimum height that the star can spawn between
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;
        //spawn a new star based on random range

        if(starColor.Equals("Purple"))
        {
        Instantiate(purpleStar, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
        }
        else if(starColor.Equals("Green"))
        {
        Instantiate(greenStar, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation); 
        }
        else if(starColor.Equals("Blue"))
        {
        Instantiate(blueStar, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation); 
        }
    }
}
