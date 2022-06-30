using System.Collections;
using Gameplay.Unit;
using Gameplay.Unit.UnitUtility;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Gameplay.AI
{
    [RequireComponent(typeof(UnitSpawner))]
    public class AISpawner : MonoBehaviour
    {
        [SerializeField] private float spawnTimer;
        [SerializeField] private UnityEvent<int> spawnEvent;

        [Header("Dependencies")]
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object enemyHand;
        [SerializeField] private WaveCollectionSO waves;
        
        private int waveCounter;
        private int counter = 0;

        private void Start() => StartCoroutine(SpawnEnemyUnit());
        
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
            else  yield return null;
        }
    }
}


