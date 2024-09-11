using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : Object
{
    [SerializeField] private int healingFactor;
    
    protected override void PickUp(Rigidbody other)
    {
        if (!other.GetComponent<Health>()) return;
        other.GetComponent<Health>().ChangeHealth(healingFactor);
    }
}
