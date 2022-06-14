using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using TMPro;
using UnityEngine;

public class TemporaryEndOfGameDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text endOfGameText;
    [SerializeField] private GameObject relayGameObject;
    private IEndOfGame endOfGame;
    
    
    // Start is called before the first frame update
    void Start()
    {
        endOfGame = relayGameObject.GetComponent<IEndOfGame>();
        endOfGame.OnWin += () => { endOfGameText.text = "You won!";};
        endOfGame.OnLose += () => { endOfGameText.text = "You lost!";};
    }
}
