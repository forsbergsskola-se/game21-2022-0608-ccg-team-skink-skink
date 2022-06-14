using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.AI.Unit
{
    public class MoveToTarget : MonoBehaviour
    {
        private Transform target;
        
        
        private void Awake()
        {
            var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            target = cylinder.transform;
            target.transform.position = new Vector3(-9f, 1.5f, 0.2f);
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(transform.position, target.position)< 0.01f)
            {
                
            }
        }
    }
}

