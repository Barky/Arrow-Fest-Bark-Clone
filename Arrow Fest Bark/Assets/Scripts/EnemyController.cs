using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ArrowMultiplier arrow_multiplier;

    private void Awake()
    {
        arrow_multiplier = GameObject.Find("ArrowController").GetComponent<ArrowMultiplier>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Arrow"))
        {
            
            arrow_multiplier.DestroyArrow(1);
            Behaviour.Destroy(this);
        }
    }
}
