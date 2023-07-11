using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPCManager
{
    private Transform target;
    private Vector2 direction;
    public GameObject enemyMissile;
    [SerializeField] private float shotCoolDown = 6f;
     

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
        // StartCoroutine(ShootAtPlayer());
        InvokeRepeating("ShootAtPlayer", 6, shotCoolDown);
    }

    // Update is called once per frame
    void Update()
    {
        BoundaryControl();
        FollowPlayer();
    }

    void FollowPlayer()
    {
        direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        // Manca l'instantiate del proiettile, con un cool down di qualche secondo;
    }

    void ShootAtPlayer()
    {
        Instantiate(enemyMissile, transform.position, transform.rotation);
    }
}
