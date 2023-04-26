using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawnerScript : MonoBehaviour
{
    public GameObject star;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 8;



    // Start is called before the first frame update
    void Start()
    {

        spawnStar();

    }

    // Update is called once per frame
    void Update()
    {

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

    public void spawnStar() {

        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;

        Instantiate(star, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);

    }
}
