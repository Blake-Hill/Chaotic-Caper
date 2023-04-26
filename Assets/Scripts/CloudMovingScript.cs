using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovingScript : MonoBehaviour
{
    //cloud move speed variable
    public float moveSpeed = 12.5f;
    //despawn x coordinate for when clouds move off screen
    public float despawnZone = -45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the cloud left based on cloud speed each frame
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //If a cloud moves outside of view the object is destroyed
        if (transform.position.x < despawnZone)
        {
            Destroy(gameObject);
        }
    }
}
