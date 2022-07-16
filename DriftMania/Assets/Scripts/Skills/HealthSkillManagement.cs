using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSkillManagement : MonoBehaviour
{
    // COOLDOWN VALUES
    float coolDown;
    float coolTime = 2f;
    bool cool;
    [SerializeField] Image healthImg;

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

                StartCoroutine("HCoolDown");                
            }            
        }
    }

    IEnumerator HCoolDown()
    {
        coolDown = 0;
        while (true)
        {
            coolDown += Time.deltaTime;
            healthImg.fillAmount = coolDown / coolTime;

            if (coolDown >= coolTime)
            {
                cool = false;
                StopCoroutine("HCoolDown");
            }

            yield return null;
        }
    }
}
