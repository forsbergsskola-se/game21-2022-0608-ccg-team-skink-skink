using Gameplay.AI.Unit;
using UnityEngine;

namespace Gameplay
{
    public class UnitSpawner : MonoBehaviour
    {
        [Header("Dependencies")]
        public GameObject unit;

        [Header("Base SetUp")] 
        [SerializeField] private string unitTag;
        [SerializeField] private string targetTag;
        [SerializeField] private Vector3 direction;
    
        //spawns unit at the selected spawnPoint
        public void Spawn()
        {
            var temp = Instantiate(unit, transform.position, Quaternion.identity);
            temp.tag = unitTag;
            UnitAI ai = temp.GetComponentInChildren<UnitAI>(); 

            ai.Target = targetTag;
            ai.Direction = direction;
        }
    }
}
