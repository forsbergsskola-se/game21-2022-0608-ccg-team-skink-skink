using Meta.Interfaces;
using UnityEngine;
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
            UnitAI ai = temp.GetComponentInChildren<UnitAI>(); 

            ai.Target = SetTag(!isPlayer);
            ai.Direction = SetDirection(transform.position.x);
        }

        private void SetTransform(GameObject temp)
        {
            var position = transform.position;
            
            temp.transform.position = position;
            temp.transform.Rotate(SetRotation(position.x));
            temp.tag = SetTag(isPlayer);
        }

        private string SetTag(bool player)
            => player ? "Player" : "Enemy";

        private Vector3 SetRotation(float positionX)
        {
            float y = 0;
            if (positionX > 0) y = 180;

            return new Vector3(0, y, 0);
        }

        private Vector3 SetDirection(float positionX)
        {
            var x = Mathf.Clamp(positionX * -1, -1, 1);
            return new Vector3(x, 0, 0);
        }
    }
}
