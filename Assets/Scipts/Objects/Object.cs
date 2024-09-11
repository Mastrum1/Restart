using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        PickUp(other.rigidbody);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Rigidbody>())
            PickUp(other.GetComponentInParent<Rigidbody>());
    }

    protected abstract void PickUp(Rigidbody other);
}
