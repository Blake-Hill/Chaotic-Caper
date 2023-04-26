using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TriggerLogic : MonoBehaviour
{

    public CatScript cat;

    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cat = GameObject.FindGameObjectWithTag("Cat").GetComponent<CatScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && cat.catIsAlive)
        {
            logic.addScore(1);
        }
    }
}
