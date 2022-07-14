using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillManagement : MonoBehaviour
{
    float nextFireTime = 0;

    // HEALTH SKILL VALUES
    
    // TIME SKILL VALUES
    float timeCoolDownTime = 5f;

    float timeSkillCD = 2f;

    private void Start()
    {
        timeSkillCD = Time.deltaTime;
    }

    void Update()
    {
        TimeSkill();
    }
    public void TimeSkill()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // CD
                nextFireTime = Time.time + timeCoolDownTime;

                timeSkillCD--;
                Time.timeScale = 0.5f;
                // CameraManagement.Instance.CameraZoom();

                if (timeSkillCD == 0)
                {
                    Time.timeScale = 1;
                }
            }
        }
              
    }
}
