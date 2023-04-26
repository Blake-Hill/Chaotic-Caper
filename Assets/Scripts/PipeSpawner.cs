using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate  = 2;
    public float timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {

        spawnPipe();

    }

    // Update is called once per frame
    void Update()
    {



        if (timer < spawnRate)
        {

            timer += Time.deltaTime;

        }
        else {

            timer = 0;

            spawnPipe();

        }

    }

    void spawnPipe(){

        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;


        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);

    }
}
