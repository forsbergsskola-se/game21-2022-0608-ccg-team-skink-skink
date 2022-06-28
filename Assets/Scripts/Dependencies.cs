using System;
using System.Collections;
using System.Collections.Generic;
using Meta.CardSystem;
using UnityEngine;

public class Dependencies : MonoBehaviour
{
    public PlayerCardHand PlayerCardHand;
    public Dependencies Instance { get; private set; }
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
