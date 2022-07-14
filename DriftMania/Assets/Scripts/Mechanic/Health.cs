using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }

    float health;

    float maxHealth = 100f;

    float minHealth = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void HealthIncrease()
    {
        health += 10;
    }

    public void HealthDecrease()
    {
        health -= 10;
        GUIManagement.Instance.FillHealth(health);
        if (health <= minHealth)
        {
            // restart scene
        }
        
    }
}
