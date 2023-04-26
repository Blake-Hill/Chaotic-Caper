using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTROLS THE MOVEMENT OF THE PIPES(OBSTACLES)

public class PipeMove : MonoBehaviour
{
    //pipe moving variables
    public float moveSpeed;
    public float despawnZone = -45;

    //start is called before the first frame update
    void Start()
    {
        
    }

    //update is called once per frame
    void Update()
    {
        //each frame move the pipes left based on move speed and deltaTime  
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        
        //despawn pipe when it leaves screen
        if (transform.position.x < despawnZone) {
            Destroy(gameObject);
        }

    }
}
