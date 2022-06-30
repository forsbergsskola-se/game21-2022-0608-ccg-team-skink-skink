using System;
using System.Linq;
using Meta.Interfaces;
using UnityEngine;

public class GameCards : MonoBehaviour
{
    public ICard[] AllLoadedCards { get; private set; }
    
    private void Awake()
    {
        // AllLoadedCards = Array.ConvertAll(Resources.LoadAll("Cards"), input => input as ICard);
        AllLoadedCards = Resources.LoadAll("Cards", typeof(ICard)).Cast<ICard>().ToArray();
        Debug.Log(AllLoadedCards);
        Debug.Log(AllLoadedCards.Length);
    }
}
