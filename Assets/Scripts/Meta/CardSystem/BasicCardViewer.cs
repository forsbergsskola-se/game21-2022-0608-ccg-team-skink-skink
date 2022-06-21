using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicCardViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text actionPointCostText;
    [SerializeField] private Image cardImage;

    public void SetCard(ICard card)
    {
        actionPointCostText.text = card.ApCost.ToString();
        cardImage.sprite = card.Image;
    }
}
