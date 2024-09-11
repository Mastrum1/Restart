using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected string name = "";
    [SerializeField] protected bool gravity = false;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected float lifeTime { get; private set; } = 5f;
    [SerializeField] protected float speed = 300f;
    
    public float LifeTime
    {
        get => lifeTime;
        private set => lifeTime = value;
    }

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _collider;

    public float getLifeTime()
    {
        return lifeTime;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rb.useGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lunch()
    {
        _rb.AddForce(gameObject.transform.forward*speed);
        StartCoroutine(Die());
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        //Code here in Override what happen on collision 
        Debug.Log("Hit");
        Health targetHealth; 
        other.gameObject.TryGetComponent<Health>(out targetHealth);
        if (targetHealth)
        {
            targetHealth.ChangeHealth(-damage);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
