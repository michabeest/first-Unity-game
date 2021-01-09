using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
public class spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float timer = 3f;
    public int wave;
    Vector2 spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            for (int i = 0; i < wave; i++)
            {
                GameObject curPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                spawnpoint.x = Random.Range(-200, 200);
                spawnpoint.y = Random.Range(-80, 80);
                if (Vector2.Distance(spawnpoint, player.position) > 10)
                {
                    GameObject enemy = Instantiate(curPrefab, spawnpoint, transform.rotation);
                }
                timer = 8;
            }
            wave += 1;
           
        }
    }
}
