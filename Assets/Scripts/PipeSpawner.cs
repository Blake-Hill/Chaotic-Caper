using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTROLS THE SPAWNING OF PIPES(OBSTACLES)

public class PipeSpawner : MonoBehaviour
{
    //create game objects to hold the pipe prefabs, be sure to link it in unity! 
    public GameObject redPipe;
    public GameObject bluePipe;
    public GameObject pinkPipe;
    public GameObject greenPipe;
    public GameObject orangePipe;

    //Variable to hold currently equipped pipe color
    public string pipeColor;

    //pipe spawning variables
    public float spawnRate  = 2;
    public float timer = 0;
    public float heightOffset = 10;

    //start is called before the first frame update
    void Start()
    {
        pipeColor = "Red";
        spawnPipe(pipeColor);
    }

    //update is called once per frame
    void Update()
    {
        //pipe spawning timer logic
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else {
            timer = 0;
            spawnPipe(pipeColor);
        }
    }

    //pipe spawning method
    void spawnPipe(string pipeColor)
    {
        //create a minimum and maximum height for random spawn range
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;
        
        //determine what color pipe to spawn, then spawn pipe
        switch(pipeColor)
        {
            //Red Pipe
            case "Red":
            Instantiate(redPipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
            break;
            //Pink Pipe
            case "Pink":
            Instantiate(pinkPipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
            break;
            //Blue Pipe
            case "Blue":
            Instantiate(bluePipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
            break;
            //Green Pipe
            case "Green":
            Instantiate(greenPipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
            break;
            //Orange Pipe
            case "Orange":
            Instantiate(orangePipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
            break;
            //Spawn red pipes if all else fails
            default:
            Instantiate(redPipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
            break;
            
        }
    }
}
