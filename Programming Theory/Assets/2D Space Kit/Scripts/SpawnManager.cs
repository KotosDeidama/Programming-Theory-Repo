using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies =  new List<GameObject> ();
    private int waveNum = 1;
    private Vector2 position;
    private int index;
    private Rigidbody2D asteroidRb;
    private Rigidbody2D enemyshipRb;
    public TMP_Text waveText;
    public TMP_Text gameOverText;
    private float asteroidForce = 1.5f;
    private float enemyForce = 2f;

    [SerializeField]
    private float spawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        while (!GameObject.FindGameObjectWithTag("Asteroid"))
        {
            StartCoroutine(SpawnEnemies());
        }
        
    }

    IEnumerator SpawnEnemies()
    {
        waveText.text = "Wave: " + waveNum;
        
        for (int i = 0; i < 4 + waveNum; i++)
        {
            position = new Vector2(Random.Range(-8f,8f), Random.Range(-5f, 5f));
            index = Random.Range(0, 2);
            var asteroid = Instantiate(enemies[index], position, Quaternion.identity);
            asteroidRb = asteroid.GetComponent<Rigidbody2D>();
            asteroidRb.velocity = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)) * asteroidForce;
            yield return new WaitForSeconds(spawnTime);
        }

        if (waveNum > 3)
        {
            for (int i = 0; i < waveNum; i++)
            {
                position = new Vector2(Random.Range(-8f,8f), Random.Range(-5f, 5f));
                var enemy = Instantiate(enemies[2], position, Quaternion.identity);
                enemyshipRb = enemy.GetComponent<Rigidbody2D>();
                enemyshipRb.velocity = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)) * enemyForce;
                yield return new WaitForSeconds(spawnTime);

            }

        }
        waveNum++;
    }
    
}
