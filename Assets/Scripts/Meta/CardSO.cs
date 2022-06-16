using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardSO : ScriptableObject, ICard
{
    [SerializeField] string cardTitle;
    [SerializeField] int level;
    [SerializeField] int apCost;
    [SerializeField] GameObject unitPrefab;

    public string Name => cardTitle;
    public int CardLevel => level;
    public int ApCost => apCost;
    public GameObject CardObject => unitPrefab;
}
