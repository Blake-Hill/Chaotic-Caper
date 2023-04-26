using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawnerScript : MonoBehaviour
{

    //create a game object to hold the star prefab, be sure to link it in unity! 
    public GameObject star;

    //star moving logic variables
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 8;

    //start is called before the first frame update
    void Start()
    {
        spawnStar();
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
            timer = 0;
            spawnStar();
        }
    }
    //spawn star method
    public void spawnStar() {
        //create a maximum and minimum height that the star can spawn between
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;
        //spawn a new star based on random range
        Instantiate(star, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
    }
}
