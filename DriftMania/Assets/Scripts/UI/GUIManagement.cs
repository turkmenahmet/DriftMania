using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManagement : MonoBehaviour
{
    public static GUIManagement Instance { get; set; }

    [SerializeField] Image healthBar;
    [SerializeField] Image nitroBar;

    private float currentHealth;

    float coolDown;
    float coolTime = 2f;
    bool cool;

    private void Awake()
    {
        Instance = this;
    }

    public void FillHealth(float cHealth)
    {
        currentHealth = cHealth;
        healthBar.fillAmount = currentHealth / 100;
        if (currentHealth == 0)
        {
            healthBar.fillAmount = 0;
        }
    }

    public void FillNitro()
    {
        if (!cool)
        {
            if (true)
            {
                cool = true;

                CarController.Instance.NitroSpeedIncrease();
                CameraManagement.Instance.CameraShake(3.5f, 2f);

                StartCoroutine("NCoolDown");
            }            
        }
    }

    IEnumerator NCoolDown()
    {
        coolDown = 0;
        while (true)
        {
            coolDown += Time.deltaTime;
            nitroBar.fillAmount = coolDown / coolTime;

            if (coolDown >= coolTime)
            {
                cool = false;
                StopCoroutine("NCoolDown");
            }

            yield return null;
        }
    }
}
