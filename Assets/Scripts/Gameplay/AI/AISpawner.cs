using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.AI.Unit;
using Gameplay.Unit;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Utility;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class AISpawner : MonoBehaviour
{
    [SerializeField, RequireInterface(typeof(ICardHand))] private Object enemyHand;
    public UnityEvent<int> spawnEvent;
    public List<EnemyAI> enemies = new List<EnemyAI>();
    public int currentWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public Pool pool;

    public Transform spawnLocation;
    public int waveDuration; 
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    private void Start()
    {
        StartCoroutine(SpawnEnemyUnit());
       GenerateWave();
    }

    void FixedUpdate ()
    {
        
    }

    private IEnumerator SpawnEnemyUnit()
    {
        spawnEvent.Invoke(1);
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(SpawnEnemyUnit());
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();
        
        //provides fixed time between enemies
        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        //create temp list of enemies to generate in loop
        //if can afford, add to list and deduct cost
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randomEnemyID = Random.Range(0, enemies.Count);
            int randomEnemyCost = enemies[randomEnemyID].cost;

            if (waveValue - randomEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemyID].enemyPrefab);
                waveValue -= randomEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class EnemyAI
{
    public GameObject enemyPrefab;
    public int cost;
}
