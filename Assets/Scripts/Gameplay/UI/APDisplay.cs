using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class APDisplay : MonoBehaviour
{
   private TextMeshProUGUI text;

   private void Awake()
   {
      text = GetComponent<TextMeshProUGUI>();
   }

   public void UpdateAPDisplay(uint currentAP)
   {
      text.text = currentAP.ToString();
   }
}
