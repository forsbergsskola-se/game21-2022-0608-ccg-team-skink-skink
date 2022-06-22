using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class APCounter : MonoBehaviour
{
    [SerializeField] private ActionPointsSO actionPointsSO;
    private uint currentAP;
    private bool isUpdating = false;

    private void Awake()
    {
        currentAP = actionPointsSO.StartAP;
    }

    private void FixedUpdate()
    {
        if (currentAP < actionPointsSO.MaxAP && !isUpdating)
        {
            isUpdating = true;
            StartCoroutine(UpdateAP());
        }
    }

    private IEnumerator UpdateAP()
    {
        
        while (isUpdating)
        {
            currentAP++;
            yield return new WaitForSeconds(actionPointsSO.APRegen);
            Debug.Log("You getting more AP by the minute buddy" + currentAP);
            if (currentAP == actionPointsSO.MaxAP)
            {
                isUpdating = false;
                Debug.Log("Dude, you gotta spend it too!");
            }
        }

        yield return null;
    }
}
