using System;
using Gameplay.AI.Unit;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class UnitSpawner : MonoBehaviour
    {

        //[Header("Dependencies")]
        public GameObject unit;

        [Header("Base SetUp")] 
        [SerializeField] private bool isPlayer;
        
        //spawns unit at the selected spawnPoint
        public void SpawnUnit()
        {
            //Todo: Connect with the pool
            var temp = Instantiate(unit, transform.position, Quaternion.identity);
            temp.tag = SetTag(isPlayer);
            UnitAI ai = temp.GetComponentInChildren<UnitAI>(); 

            ai.Target = SetTag(!isPlayer);
            ai.Direction = SetDirection(ai.transform.position.x);
        }

        private string SetTag(bool player)
            => player ? "Player" : "Enemy";

        private Vector3 SetDirection(float positionX)
            => new Vector3(positionX * -1, 0, 0).normalized;
        
    }
}
