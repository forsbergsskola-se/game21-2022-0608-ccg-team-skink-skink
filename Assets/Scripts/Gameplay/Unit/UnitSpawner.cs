using Gameplay.AI.Unit;
using Meta.Interfaces;
using UnityEngine;
using Utility;

namespace Gameplay.Unit
{
    public class UnitSpawner : MonoBehaviour
    {

        [Header("Dependencies")]
        [SerializeField] public Pool pool;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object playerHand;

        [Header("Base SetUp")] 
        [SerializeField] private bool isPlayer;

        public void SpawnUnit(int buttonId)
        {
            ICardHand hand = playerHand as ICardHand;
            
            PlaceUnit(hand.Cards[buttonId].Name);
        }

        private void PlaceUnit(string unitName)
        {
            var temp = pool.GetInstance(unitName);
            temp.transform.position = transform.position;
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
