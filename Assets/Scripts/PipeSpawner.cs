using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTROLS THE SPAWNING OF PIPES(OBSTACLES)

public class PipeSpawner : MonoBehaviour
{
    //create a game object to hold the pipe prefab, be sure to link it in unity! 
    public GameObject pipe;

    //pipe spawning variables
    public float spawnRate  = 2;
    public float timer = 0;
    public float heightOffset = 10;

    //start is called before the first frame update
    void Start()
    {
        spawnPipe();
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
            spawnPipe();
        }
    }

    //pipe spawning method
    void spawnPipe(){
        //create a minimum and maximum height for random spawn range
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;

        //create a new pipe object with random y value
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
    }
}
