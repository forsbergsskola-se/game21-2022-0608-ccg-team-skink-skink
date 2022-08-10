using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class RewardPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public void GiveNormalCoins(int value)
    {
        Debug.Log("Coins before rewards  :"+Dependencies.Instance.NormalCoinCarrier.Amount);
        Dependencies.Instance.NormalCoinCarrier.Amount += value;
        Debug.Log("Coins after rewards  :"+Dependencies.Instance.NormalCoinCarrier.Amount);
    }
}
