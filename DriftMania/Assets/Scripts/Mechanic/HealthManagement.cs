using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
    float coolDown;
    float coolTime = 2f;
    bool cool;
    [SerializeField] Image healthImg;

    private void Start()
    {
        
    }

    private void Update()
    {
        HealthSkill();
    }

    public void HealthSkill()
    {
        if (!cool)
        {
            healthImg.fillAmount = 1;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                cool = true; 
                Health.Instance.HealthIncreaseSkill();
                StartCoroutine("CoolDown");                
            }            
        }
    }

    IEnumerator CoolDown()
    {
        coolDown = 0;
        while (true)
        {
            coolDown += Time.deltaTime;
            healthImg.fillAmount = coolDown / coolTime;

            if (coolDown >= coolTime)
            {
                cool = false;
                StopCoroutine("CoolDown");
            }

            yield return null;
        }
    }

}
