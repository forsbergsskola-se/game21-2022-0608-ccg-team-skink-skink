using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject unit1;

    //TODO: remove update input, keep until done testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Spawn1();
        }
    }
    
    //spawns unit at the selected spawnPoint
    public void Spawn1()
    {
        Instantiate(unit1, spawnPoint);
    }
}
