using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject shoot_effect;
    public GameObject hit_effect;
    public GameObject firing_ship;
    private Rigidbody2D missileRigidbody2D;
    private float missileSpeed = 2000f;
    // Start is called before the first frame update
    void Start()
    {
        firing_ship = GameObject.FindWithTag("Enemy");
        missileRigidbody2D = GetComponent<Rigidbody2D>();
        GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position  - new Vector3(0,0,5), Quaternion.identity); //Spawn muzzle flash
        obj.transform.parent = firing_ship.transform;
        Destroy(gameObject, 2f); //Bullet will despawn after x seconds
    }

    // Update is called once per frame
    void Update()
    {
        missileRigidbody2D.velocity = transform.up * missileSpeed * Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        //Don't want to collide with the ship that's shooting this thing, nor another projectile.
        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Projectile" && col.gameObject.tag != "Asteroid") {
            Instantiate(hit_effect, transform.position, transform.rotation);
            Destroy(gameObject);

            if (col.gameObject.tag == "Ship")
            {
                Destroy(col.gameObject);
            }
        }
    }
}
