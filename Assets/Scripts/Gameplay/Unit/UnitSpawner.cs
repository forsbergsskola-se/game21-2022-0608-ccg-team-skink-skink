using Gameplay.Unit;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Gameplay.Unit
{
    public class UnitSpawner : MonoBehaviour
    {

        [Header("Dependencies")]
        [SerializeField] private Pool pool;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object deckHand;

        [Header("Base SetUp")] 
        [SerializeField] private bool isPlayer;

        public void SpawnUnit(int buttonId)
        {
            ICardHand hand = deckHand as ICardHand;
            
            PlaceUnit(hand.Cards[buttonId].Name);
        }

        private void PlaceUnit(string unitName)
        {
            var temp = pool.GetInstance(unitName);
            SetTransform(temp);
            temp.tag = SetTag(isPlayer);
            UnitAI ai = temp.GetComponentInChildren<UnitAI>(); 

            ai.Target = SetTag(!isPlayer);
            ai.Direction = SetDirection(isPlayer);
        }

        private void SetTransform(GameObject temp)
        {
            temp.transform.position = transform.position;
            temp.transform.eulerAngles = transform.eulerAngles;
        }

        private string SetTag(bool player)
            => player ? "Player" : "Enemy";

        private Vector3 SetDirection(bool player)
            => player? new Vector3(-1, 0, 0) : new Vector3(1, 0, 0);
        
    }
}
