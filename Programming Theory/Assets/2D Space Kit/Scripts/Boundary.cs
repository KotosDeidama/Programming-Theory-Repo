using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        BoundaryControl();
    }
    
    private void BoundaryControl()
    {
        if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y,0);
        }
        else if (transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y,0);
        }

        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, -5,0);
        }
        else if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, 5 ,0);
        }
    }
}
