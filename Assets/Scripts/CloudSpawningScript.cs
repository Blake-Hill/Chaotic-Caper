using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudSpawningScript : MonoBehaviour
{

    public GameObject cloud;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 3;
    public float sizeOffset = .5F;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cloud.GetComponent<CloudMovingScript>().moveSpeed = moveSpeed;
        spawnCloud();
       
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

            spawnCloud();

        }

    }

    void spawnCloud() {

        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;

        float minScale = transform.localScale.x - sizeOffset;

        
        GameObject tempCloud = Instantiate(cloud, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), transform.position.z), transform.rotation);
        float rand = Random.Range(minScale, tempCloud.transform.localScale.x);
        tempCloud.transform.localScale = new Vector3(rand, rand, 1);
    }
}
