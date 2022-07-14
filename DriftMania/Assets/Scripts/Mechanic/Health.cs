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

    private void Update()
    {
        print("<color=#ffa900>HEALTH </color>" + health);
        print("<color=#ff0000>TIME </color>" + Time.timeScale);
    }

    public void HealthIncreaseSkill()
    {
        health += 20;
        GUIManagement.Instance.FillHealth(health);
        if (health >= 100)
        {
            health = 100;
        }
    }

    public void HealthDecrease()
    {
        health -= 10;
        GUIManagement.Instance.FillHealth(health);
        if (health <= minHealth)
        {
            // restart scene
        }
        if (health < 30)
        {
            CameraManagement.Instance.CameraShake(7f, 1f);
        }
    }
}
