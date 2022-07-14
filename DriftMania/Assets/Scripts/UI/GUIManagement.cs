using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManagement : MonoBehaviour
{
    public static GUIManagement Instance { get; set; }

    [SerializeField] Image healthBar;
    [SerializeField] Image nitroBar;
    [SerializeField] Image healthSkill;
    [SerializeField] Image nitroSkill;
    [SerializeField] Image powerSkill;

    private float currentHealth;

    private void Awake()
    {
        Instance = this;
    }

    public void FillHealth(float cHealth)
    {
        currentHealth = cHealth;
        healthBar.fillAmount = currentHealth / 100;
        if (currentHealth <= 0)
        {
            healthBar.fillAmount = 0;
        }
    }
}
