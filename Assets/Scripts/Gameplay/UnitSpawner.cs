using Gameplay.AI.Unit;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class UnitSpawner : MonoBehaviour
    {
        [Header("Dependencies")]
        public GameObject unit;

        [FormerlySerializedAs("isPlayerBase")]
        [Header("Base SetUp")] 
        [SerializeField] private bool isPlayer;
        [SerializeField] private Vector3 direction;
    
        //spawns unit at the selected spawnPoint
        public void Spawn()
        {
            var temp = Instantiate(unit, transform.position, Quaternion.identity);
            temp.tag = SetTag(isPlayer);
            UnitAI ai = temp.GetComponentInChildren<UnitAI>(); 

            ai.Target = SetTag(!isPlayer);
            ai.Direction = direction;
        }

        private string SetTag(bool player) => player ? "Player" : "Enemy";
    }
}
