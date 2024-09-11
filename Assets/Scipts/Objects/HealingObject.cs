using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : Object
{
    [SerializeField] private int healingFactor;
    [SerializeField] private float coolDown;
    private bool waiting;
    private MeshRenderer mesh;
    private Collider col;
    [SerializeField] private Material mat;
    [SerializeField] private Material matCoolDown;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        if (!mat)
            mat = mesh.material;
        else
            mesh.material = mat;
        col = gameObject.GetComponent<Collider>();
    }

    protected override void PickUp(Rigidbody other)
    {
        if (!other.GetComponent<Health>() || waiting) return;
        other.GetComponent<Health>().ChangeHealth(healingFactor);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        if(matCoolDown)
            mesh.material = matCoolDown;
        waiting = true;
        col.enabled = false;
        yield return new WaitForSeconds(coolDown);
        waiting = false;
        mesh.material = mat;
        col.enabled = true;
    }
}
