using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> asteroids =  new List<GameObject> ();
    private int waveNum = 1;
    private Vector2 position;
    private int index;
    private Rigidbody2D asteroidRb;
    private float asteroidForce = 1.5f;

    [SerializeField]
    private float spawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    // Update is called once per frame
    void Update()
    {
        // if (GameObject.FindGameObjectWithTag("Asteroid"))
        // {
        //     Debug.Log(GameObject.FindGameObjectWithTag("Asteroid").gameObject.name);
        //     return;
        // }

        while (!GameObject.FindGameObjectWithTag("Asteroid"))
        {
            StartCoroutine(SpawnAsteroids());
        }
        
    }

    IEnumerator SpawnAsteroids()
    {
        for (int i = 0; i < 4 + waveNum; i++)
        {
            position = new Vector2(Random.Range(-8f,8f), Random.Range(-5f, 5f));
            index = Random.Range(0, 2);
            var asteroid = Instantiate(asteroids[index], position, Quaternion.identity);
            asteroidRb = asteroid.GetComponent<Rigidbody2D>();
            asteroidRb.velocity = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)) * asteroidForce;
            yield return new WaitForSeconds(spawnTime);
        }

        waveNum++;
    }
    
}
