using System.Collections;
using UnityEngine;
using Utility;

namespace Meta.Ads
{
    public class RewardPlayer : MonoBehaviour
    {
        public void GiveNormalCoins(int value)
        {
            StopAllCoroutines();
            StartCoroutine(Reward(value));
        }

        private IEnumerator Reward(int value)
        {
            yield return new WaitForSeconds(0.2f);
            Dependencies.Instance.NormalCoinCarrier.Amount += value;
        }
    }
}
