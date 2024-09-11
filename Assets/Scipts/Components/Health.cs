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
    [SerializeField] private float _currentHealth;

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    [SerializeField] private bool isPlayer = false;
    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        healthBar.HealthUpdate();
    }

    public void ChangeHealth(int value)
    {
        _currentHealth += value;
        healthBar.HealthUpdate();
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
