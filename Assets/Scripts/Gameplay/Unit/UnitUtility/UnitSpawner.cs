using Gameplay.Unit.UnityAI;
using Meta.Interfaces;
using UnityEngine;
using Utility;
using Utility.ObjPooling;
using Object = UnityEngine.Object;

namespace Gameplay.Unit.UnitUtility
{
    public class UnitSpawner : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Pool pool;
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object enemyHand;
        
        [Header("Base SetUp")] 
        [SerializeField] private bool isPlayer;

        private ICardHand playerHand;
        
        private void Start() => playerHand = Dependencies.Instance.PlayerCardHand;
        
        public void SpawnUnit(int buttonId)
        {
            ICardHand deckHand;

            if (isPlayer) deckHand = playerHand;
            else deckHand = enemyHand as ICardHand;
            
            PlaceUnit(deckHand.Cards[buttonId].Id);
        }

        private void PlaceUnit(sbyte unitId)
        {
            var temp = pool.GetInstance(unitId);
            SetTransform(temp);

            IUnit ai = temp.GetComponentInChildren<IUnit>(); 
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
