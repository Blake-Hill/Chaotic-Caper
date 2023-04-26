using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGrabTriggerLogic : MonoBehaviour
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
        if (collision.gameObject.layer == 3 && cat.catIsAlive) {
            
            logic.addStar(1);
            Destroy(gameObject);

        }
    }

}
