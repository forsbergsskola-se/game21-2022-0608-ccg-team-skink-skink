using Meta.Interfaces;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;


namespace Meta.Development
{
    public class TemporaryPlayerCardHandCreator : MonoBehaviour
    {
        [SerializeField, RequireInterface(typeof(ICardHand))] private Object defaultCardHandSO;

        private void Awake()
        {
            var defaultCardHand = defaultCardHandSO as ICardHand;
            var playerCardHand = Dependencies.Instance.PlayerCardHand;
            
            for (int i = 0; i < playerCardHand.Cards.Length; i++)
            {
                playerCardHand[i] = defaultCardHand.Cards[i];
            }
        }
    }
}
