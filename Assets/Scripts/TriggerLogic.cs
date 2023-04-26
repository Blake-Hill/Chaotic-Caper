using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//SCORE TRIGGER LOGIC SCRIPT

public class TriggerLogic : MonoBehaviour
{
    //create a game object to hold cat 
    public CatScript cat;
    //create a logic script to hold my logicScript
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        //link game objects to their instances
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cat = GameObject.FindGameObjectWithTag("Cat").GetComponent<CatScript>();     
    }

    //On collision enter add score ammount(1 in this case)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && cat.catIsAlive)
        {
            logic.addScore(1);
        }
    }
}
