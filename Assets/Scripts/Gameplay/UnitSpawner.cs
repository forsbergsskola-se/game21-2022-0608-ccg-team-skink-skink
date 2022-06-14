using Gameplay.AI.Unit;
using UnityEngine;

namespace Gameplay
{
    public class UnitSpawner : MonoBehaviour
    {
        [Header("Dependencies")]
        public GameObject unit;

        [Header("Base SetUp")]
        [SerializeField] private string targetTag;
        [SerializeField] private Vector3 direction;
    
        //spawns unit at the selected spawnPoint
        public void Spawn()
        {
            var temp = Instantiate(unit, transform.position, Quaternion.identity);
            UnitAI ai = temp.GetComponent<UnitAI>(); 

            ai.Target = targetTag;
            ai.Direction = direction;
        }
    }
}
