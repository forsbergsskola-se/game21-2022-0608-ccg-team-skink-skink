using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

public class APCounter : MonoBehaviour
{
    [SerializeField] private ActionPointsSO actionPointsSO;
    [SerializeField] private UnityEvent<uint> onAPUpdate;
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
            onAPUpdate.Invoke(++currentAP);
            yield return new WaitForSeconds(actionPointsSO.APRegen);
            if (currentAP == actionPointsSO.MaxAP)
            {
                isUpdating = false;
                Debug.Log("Dude, you gotta spend it too!");
            }
        }

        yield return null;
    }
}
