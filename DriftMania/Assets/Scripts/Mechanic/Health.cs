using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }

    [SerializeField] TextMeshProUGUI healthPopUP;

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
        //print("<color=#ffa900>HEALTH </color>" + health);
    }

    public void HealthIncreaseSkill()
    {
        health += 20;
        GUIManagement.Instance.FillHealth(health);
        HealthPopUp();

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
            health = 0;
        }
        if (health < 30)
        {
            CameraManagement.Instance.CameraShake(7f, 1f);
        }
    }

    private void HealthPopUp()
    {
        healthPopUP.GetComponent<RectTransform>().DOScale(.5f, 0.5f).SetEase(Ease.OutFlash);
        healthPopUP.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

        Invoke("HealthPopUpOut", 1f);
    }

    private void HealthPopUpOut()
    {
        healthPopUP.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InOutFlash);
        healthPopUP.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
    }
}
