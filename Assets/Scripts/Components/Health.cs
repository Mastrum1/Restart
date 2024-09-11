using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent PlayerDead;
    
    public float CurrentHealth
    {
        get => _currentHealth;
        private set => _currentHealth = value;
    }
    private float _currentHealth;

    [SerializeField] private bool isPlayer = false;
    [SerializeField] private float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth; 
    }

    public void ChangeHealth(int value)
    {
        _currentHealth += value;
        if (_currentHealth > maxHealth)
            _currentHealth = maxHealth;
        if (_currentHealth <= 0)
        {
            if (isPlayer)
            {
                PlayerDead.Invoke();
                Debug.Log("Player Dead");
            }
            
            else
            {
                gameObject.SetActive(false);
                //Send Enemy back to pool
            }
        }
    }
    
}
