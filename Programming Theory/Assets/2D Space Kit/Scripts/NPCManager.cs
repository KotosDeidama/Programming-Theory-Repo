using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void BoundaryControl()
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
