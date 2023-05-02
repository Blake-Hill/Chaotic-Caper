using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LOGIC FOR WHEN CHARACTER COLLISION ENTERS STAR TRIGGER

public class StarGrabTriggerLogic : MonoBehaviour
{
    //create a game object to hold the cat  
    public CatScript cat;
    //create a logicScript object to hold my logicScript
    public LogicScript logic;
    

    // Start is called before the first frame update
    void Start()
    {
        //link instances to game objects
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cat = GameObject.FindGameObjectWithTag("Cat").GetComponent<CatScript>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {       
         //on collision with cat if cat is alive add a star and destroy triggered star
        if (collision.gameObject.layer == 3 && cat.catIsAlive) {
            //if star is purple give 1 point
            if(this.tag.Equals("PurpleStar"))
            {
            logic.addStar(1);
            Destroy(gameObject);
            }
            //
            else if(this.tag.Equals("GreenStar"))
            {
            logic.addStar(3);
            Destroy(gameObject);
            }
            else if(this.tag.Equals("BlueStar"))
            {
            logic.addStar(10);
            Destroy(gameObject);
            }
        }
    }
}
