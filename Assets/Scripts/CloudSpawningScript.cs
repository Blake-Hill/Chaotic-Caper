using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//THIS SCRIPT SPAWNS CLOUDS DURING A RUN AT A SET INTERVAL AT RANDOM Y POSITIONS WITH RANDOM SCALE

public class CloudSpawningScript : MonoBehaviour
{

    //create a game object to hold the cloud prefab, be sure to link it in unity!
    public GameObject cloud;

    //variables for cloud spawning logic
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 3;
    public float sizeOffset = .5F;
    public float moveSpeed;

    //start is called before the first frame update
    void Start()
    {
        //set the cloud move speed to the in game cloud move speed
        cloud.GetComponent<CloudMovingScript>().moveSpeed = moveSpeed;

        //spawn a cloud
        spawnCloud();
    }

    //update is called once per frame
    void Update()
    {
        //cloud spawning logic
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnCloud();
        }

    }
    //cloud spawning method
    void spawnCloud() {
        //create the maximum and minimum heights for randomized cloud spawning pos
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;

        //create a minimum size for randomized cloud spawning size
        float minScale = transform.localScale.x - sizeOffset;

        //spawn a cloud with random y offset 
        GameObject tempCloud = Instantiate(cloud, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
        //create a random number for scaling the newly spawned cloud
        float rand = Random.Range(minScale, tempCloud.transform.localScale.x);
        //set random scale of newly spawned cloud
        tempCloud.transform.localScale = new Vector3(rand, rand, 1);
    }
}
