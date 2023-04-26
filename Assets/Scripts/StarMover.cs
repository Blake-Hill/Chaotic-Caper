using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMover : MonoBehaviour
{
    //star moving logic variables
    public float moveSpeed;
    public int despawnZone = -45;

    // Update is called once per frame
    void Update()
    {
        //move the star left each frame based on move speed and deltaTime
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //destroy star object if it moves off screen
        if (transform.position.x < despawnZone)
        {
            Destroy(gameObject);
        }
    }
}
