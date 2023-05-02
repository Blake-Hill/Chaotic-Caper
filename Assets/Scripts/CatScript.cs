using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//THIS SCRIPT IS IN CONTROL OF CHARACTER BEHAVIOR

public class CatScript : MonoBehaviour
{
    //Create an instance of rigidBody
    public Rigidbody2D rigidBody;
    //Create an instance of logicScript
    public LogicScript logic;
    //Create an instance of Cat
    public GameObject cat;
    //Create a sprite field to hold the flapping sprite
    public Sprite defaultCat;
    public Sprite flappingCat;

    //Create a variable for bonkSound
    [SerializeField] private AudioSource bonkSound;
    //Create a variable for flapSound
    [SerializeField] private AudioSource flapSound;
    public float flySpeed;
    public bool catIsAlive = true;

    //Bonk Animation Variables   
    public float degreesPerSec;
    private float bonkTimer;
    public float forceUp;
    public float gravity; 
    private float timer;
    public bool diedByPipe = false;
    public bool stop = false;
    public Vector3 savedVelocity;

    // Start is called before the first frame update
    void Start()
    {      
        //Connect to logic script so I can use its functions
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Flight Logic
        //Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && catIsAlive && transform.position.y < 16) 
        {           
            //Switch Sprite for faux animation
            cat.GetComponent<SpriteRenderer>().sprite = flappingCat; 
            //Play flapSound
            flapSound.Play();
            //Add upwards velocity to cat on space press
            rigidBody.velocity = Vector2.up * flySpeed;
        }
        //reset sprite to end animation
        if(Input.GetKeyUp(KeyCode.Space)){
            cat.GetComponent<SpriteRenderer>().sprite = defaultCat;
        }

        //COMMENT OUT BEFORE FINAL RELEASE
        //Clear save data when you press equals key
        if (Input.GetKeyDown(KeyCode.Equals)) {
            PlayerPrefs.DeleteAll();
        }

        //End game if you fly off the bottom of the screen
        if (transform.position.y < -16) 
        {
            if (catIsAlive)
            {
                logic.gameOver();
                catIsAlive = false;
            }
        }

        //Save cat's velocity from one second ago for bonk animation
        if (catIsAlive & timer >1) {
            savedVelocity = rigidBody.velocity;
            timer = 0;
        }

        //Bonk animation logic
        //Check if the cat game overed by pipe(game overing off screen doesnt cause bonk)
        if (!catIsAlive && diedByPipe)
        {
            //Check to see .05sec has passed so that animation
            //plays slightly after collision is deleted
            if (bonkTimer > .05)
            {
                //continuously set rotation for bonk animation
                cat.transform.Rotate(0.0f, 0.0f, degreesPerSec / 50);

                //On first iteration only
                if (!stop)
                {
                    //Add upward force and increase gravity
                    rigidBody.velocity = Vector2.up * forceUp;
                    rigidBody.gravityScale = gravity;
                    stop = true;
                }

                //Reset bonk timer to keep looping
                bonkTimer = 0;
            }
            //Add time to bonkTimer each frame
            bonkTimer += Time.deltaTime;
        }

        //Add time to timer for velocity storage each frame
        timer += Time.deltaTime;
    }
    
    //Game over on pipe collision logic
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (catIsAlive)
        {
            //Remove collision for bonk animation and reset velocity stop caused by the bonk
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            rigidBody.velocity = savedVelocity;

            //Play bonk noise
            bonkSound.Play();

            //Set gameover and change variables for after bonk logic
            logic.gameOver();
            catIsAlive = false;
            diedByPipe = true;
        }
    }    
}
