using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
 
    public Transform[] spawnPoints;
 
    public Vector3 spawnValues;
    public int spawnTick = 10;
    public int spawnAmount = 2;
    public float eTimer;
     
     
    void Update () 
    {
        eTimer = eTimer - Time.deltaTime;
        if(eTimer<0){eTimer=spawnTick;
 
            int i = spawnAmount;
            while(i>0)
            {
                i--;
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                Instantiate(enemy2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
        
    }
}
