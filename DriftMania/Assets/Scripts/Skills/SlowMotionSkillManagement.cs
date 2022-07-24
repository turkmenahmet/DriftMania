using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotionSkillManagement : MonoBehaviour
{
    // COOLDOWN VALUES
    float coolDown;
    float coolTime = 5f;
    bool cool;
    [SerializeField] Image smImg;

    private void Update()
    {
        SlowMotionSkill();
    }

    public void SlowMotionSkill()
    {
        if (!cool)
        {
            smImg.fillAmount = 1;

            if (Input.GetKeyDown(KeyCode.W))
            {
                cool = true;

                //SlowMotion();

                //StartCoroutine("SMCoolDown");
            }
        }
    }

    IEnumerator SMCoolDown()
    {
        coolDown = 0;
        while (true)
        {
            coolDown += Time.deltaTime;
            smImg.fillAmount = coolDown / coolTime;

            if (coolDown >= coolTime)
            {
                cool = false;
                StopCoroutine("SMCoolDown");
            }

            yield return null;
        }
    }

    private void SlowMotion()
    {
        Time.timeScale = 0.5f;
        // CameraManagement.Instance.CameraZoom();
        Invoke("SlowMotionOut", 1f);
    }

    private void SlowMotionOut()
    {
        Time.timeScale = 1;
    }
}
