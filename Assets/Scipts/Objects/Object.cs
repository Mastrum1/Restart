using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PickUp(other);
    }
    private void OnCollisionEnter(Collision other)
    {
        PickUp(other.collider);
    }

    protected abstract void PickUp(Collider other);
}
