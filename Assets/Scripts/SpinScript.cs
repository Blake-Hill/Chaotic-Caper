using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public float timer = 0.0f;
    public int degreesPerSec;
    public GameObject spinningStar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > .05) {

            rotateStar(degreesPerSec);
            timer = 0.0f;
                
        }

        timer += Time.deltaTime;

    }

    void rotateStar(float degreesPerSecond) {

        spinningStar.transform.Rotate(0.0f, 0.0f, degreesPerSecond / 2, Space.World);
    
    }
}
