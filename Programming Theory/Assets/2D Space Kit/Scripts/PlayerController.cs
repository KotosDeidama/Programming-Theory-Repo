using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Range(0,2000)]
    [SerializeField] private float acceleration = 1f;

    [Range(0,50)]
    [SerializeField] private float torque_acc = 0.5f;

    private Rigidbody2D playerRB;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        BoundaryControl();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) && playerRB.velocity.magnitude < 5) 
        {
            playerRB.AddForce(transform.up * acceleration * Time.deltaTime);
		
        }
        if (Input.GetKey(KeyCode.S) && playerRB.velocity.magnitude < 5) 
        {
            playerRB.AddForce((-transform.up) * acceleration * Time.deltaTime);
			
        }
        if (Input.GetKey(KeyCode.D) &&  playerRB.totalTorque < 2) {
            playerRB.AddTorque(-torque_acc  * Time.deltaTime);
			
        }
        if (Input.GetKey(KeyCode.A) && playerRB.totalTorque < 2)
        {
            playerRB.AddTorque(torque_acc * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.H)) {
            transform.position = new Vector3(0,0,0);
            playerRB.velocity = new Vector2(0,0);
            playerRB.angularVelocity = 0;
        }
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
