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

    //On collision enter if cat is alive add a star to current star count and destroy star
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && cat.catIsAlive) {
            logic.addStar(1);
            Destroy(gameObject);
        }
    }
}
