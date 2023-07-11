using System;
using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject shoot_effect;
	public GameObject hit_effect;
	public GameObject firing_ship;
	private Rigidbody2D missileRigidbody2D;
	private float missileSpeed = 3000f;
	
	// Use this for initialization
	void Start () {
		firing_ship = GameObject.FindWithTag("Ship");
		missileRigidbody2D = GetComponent<Rigidbody2D>();
		GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position  - new Vector3(0,0,5), Quaternion.identity); //Spawn muzzle flash
		obj.transform.parent = firing_ship.transform;
		Destroy(gameObject, 2f); //Bullet will despawn after x seconds
	}

	private void Update()
	{
		 missileRigidbody2D.velocity = transform.up * missileSpeed * Time.deltaTime;
		//missileRigidbody2D.AddForce(transform.forward * missileSpeed* Time.deltaTime, ForceMode2D.Impulse);
		
	}


	void OnTriggerEnter2D(Collider2D col) {
		//Don't want to collide with the ship that's shooting this thing, nor another projectile.
		if (col.gameObject.tag != "Ship" && col.gameObject.tag != "Projectile") {
			Instantiate(hit_effect, transform.position, transform.rotation);
			Destroy(gameObject);

			if (col.gameObject.tag == "Asteroid" || col.gameObject.tag == "Enemy")
			{
			 	Destroy(col.gameObject);
			}
		}
	}
}
