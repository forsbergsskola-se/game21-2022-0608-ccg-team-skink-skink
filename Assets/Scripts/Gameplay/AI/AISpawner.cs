using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.AI;
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
    [SerializeField] private WaveCollectionSO waves;
    [SerializeField] private float spawnTimer;

    private int waveCounter;
    private int counter = 0;
    public UnityEvent<int> spawnEvent;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public int waveDuration;
    
    private void Start()
    { 
       StartCoroutine(SpawnEnemyUnit());
    }

    
    private IEnumerator SpawnEnemyUnit()
    {
        spawnEvent.Invoke(waves.Collection[waveCounter].Units[counter++]);
        if (waves.Collection[waveCounter].Units.Length <= counter)
        {
            waveCounter++;
            counter = 0;
        }

        if (waveCounter < waves.Collection.Length)
        {
            yield return new WaitForSeconds(spawnTimer);
            StartCoroutine(SpawnEnemyUnit()); 
        }
        else
        {
            yield return null;
        }
    }
}


