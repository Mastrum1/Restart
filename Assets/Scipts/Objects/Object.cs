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

    protected abstract void PickUp(Rigidbody other);
}
