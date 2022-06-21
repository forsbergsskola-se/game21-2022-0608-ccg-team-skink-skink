using Gameplay.Unit;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
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
            ai.Direction = SetDirection(transform.position.x);
        }

        private void SetTransform(GameObject temp)
        {
            temp.transform.position = transform.position;
            temp.transform.eulerAngles = transform.eulerAngles;
        }

        private string SetTag(bool player)
            => player ? "Player" : "Enemy";

        private Vector3 SetDirection(float positionX)
        {
            var x = Mathf.Clamp(positionX * -1, -1, 1);
            return new Vector3(x, 0, 0);
        }
            
    }
}
